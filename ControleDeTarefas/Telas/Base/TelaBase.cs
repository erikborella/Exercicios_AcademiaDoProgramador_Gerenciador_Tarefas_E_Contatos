using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Telas.Base
{
    abstract class TelaBase
    {
        private List<OpcaoTela> opcoes = new List<OpcaoTela>();
        private int opcaoAtual = 1;

        public string descricao;

        protected enum TipoMensagem
        {
            SUCESSO, ERRO, INPUT
        }

        protected TelaBase(string descricao)
        {
            this.descricao = descricao;
        }


        public virtual TelaBase Executar()
        {
            Console.Clear();

            ImprimirMensagem(descricao, TipoMensagem.SUCESSO);
            Console.WriteLine();

            ListarOpcoes();

            Console.WriteLine();
            int opcao = LerOpcao();

            return EncontrarOpcao(opcao);
        }

        protected void AdicionarOpcao(TelaBase tela)
        {
            opcoes.Add(new OpcaoTela(opcaoAtual, tela));
            opcaoAtual++;
        }


        protected void ImprimirMensagem(string msg, TipoMensagem tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case TipoMensagem.SUCESSO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case TipoMensagem.ERRO:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case TipoMensagem.INPUT:
                    Console.Write(msg);
                    return;
            }

            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void ListarOpcoes()
        {
            foreach (OpcaoTela opcao in opcoes)
            {
                Console.WriteLine($"{opcao.N}. {opcao.Menu.descricao}");
            }
            Console.WriteLine($"{opcaoAtual}. Voltar");
        }

        protected int LerInt()
        {
            while (true)
            {
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    return n;
                }
                catch (Exception)
                {
                    ImprimirMensagem("Digite um numero!", TipoMensagem.ERRO);
                }
            }
        }

        protected string LerString()
        {
            while (true)
            {
                string str = Console.ReadLine();

                if (string.IsNullOrEmpty(str))
                    ImprimirMensagem("Digite alguma coisa!", TipoMensagem.ERRO);
                else
                    return str;
            }
        }

        protected string LerStringComTamanho(int tamanho)
        {
            while (true)
            {
                string str = LerString();

                if (str.Length == tamanho)
                    return str;
                else
                    ImprimirMensagem($"Voce deve digitar exatamente {tamanho} letras", TipoMensagem.ERRO);
            }
        }

        protected int LerNoIntervalo(int min, int max)
        {
            while (true)
            {
                int n = LerInt();

                if (EstaForaDoIntervalo(min, max, n))
                    ImprimirMensagem("O numero digitado não é valido!", TipoMensagem.ERRO);
                else
                    return n;
            }
        }

        protected DateTime LerData()
        {
            while (true)
            {
                try
                {
                    string dataStr = Console.ReadLine();
                    DateTime data = DateTime.Parse(dataStr);

                    return data;
                }
                catch (Exception)
                {
                    ImprimirMensagem("Digite uma data no formato dd/mm/aaaa", TipoMensagem.ERRO);
                    continue;
                }
            }
        }

        protected TimeSpan LerHora()
        {
            while (true)
            {
                try
                {
                    string horaStr = Console.ReadLine();
                    TimeSpan hora = TimeSpan.Parse(horaStr);

                    if (hora.Days != 0)
                        throw new Exception();

                    return hora;
                } 
                catch (Exception)
                {
                    ImprimirMensagem("Digite um horario no formato hh:mm:ss", TipoMensagem.ERRO);
                    continue;
                }
            }
        }

        protected void Pausar()
        {
            Console.WriteLine();
            Console.Write("Digite qualquer coisa para continuar: ");

            Console.ReadLine();
        }

        protected void ImprimirRegistros<T>(string[] nomesColunas, 
            T[] registros, Func<T, object[]> obterValoresLinha)
        {
            string[][] valores = ExtrairValoresLinhas(registros, obterValoresLinha, nomesColunas.Length);

            string template = GerarTemplate(nomesColunas, valores);

            Console.WriteLine(template, nomesColunas);

            Console.WriteLine();

            if (registros.Length == 0)
                Console.WriteLine("Nenhum registro encontrado");

            foreach(string[] valoresLinha in valores)
            {
                Console.WriteLine(template, valoresLinha);
            }
        }


        private string[][] ExtrairValoresLinhas<T>(T[] registros,
            Func<T, object[]> obterValoresLinha, int nColunas)
        {
            string[][] valores = new string[registros.Length][];

            for (int i = 0; i < registros.Length; i++)
            {
                object[] valoresLinha = obterValoresLinha(registros[i]);

                if (valoresLinha.Length != nColunas)
                    throw new ArgumentOutOfRangeException(
                        "A quantidade de valores não fecham com a quantidade de colunas",
                        nameof(registros));

                valores[i] = valoresLinha
                    .Select(registro => 
                        (registro != null) ? registro.ToString() : "")
                    .ToArray();
            }

            return valores;
        }

        private string GerarTemplate(string[] nomesColunas, string[][] valores)
        {
            StringBuilder templateTemp = new StringBuilder();

            for (int i = 0; i < nomesColunas.Length; i++)
            {
                templateTemp.Append($"{{{i}, -{ObterTamanhoMaximoColuna(nomesColunas[i], i, valores)}}}");

                if (i != nomesColunas.Length - 1)
                    templateTemp.Append(" | ");
            }

            return templateTemp.ToString();
        }

        private int ObterTamanhoMaximoColuna(string nomeColuna, int posicaoValores, string[][] valores)
        {
            int tamanhoMaximo = nomeColuna.Length;

            for (int i = 0; i < valores.Length; i++)
            {
                string valorColuna = valores[i][posicaoValores];

                if (valorColuna.Length > tamanhoMaximo)
                    tamanhoMaximo = valorColuna.Length;
            }

            return tamanhoMaximo;
        }

        private static bool EstaForaDoIntervalo(int min, int max, int n)
        {
            return n < min || n > max;
        }

        private int LerOpcao()
        {
            Console.Write("Digita o que deseja fazer: ");
            while (true)
            {
                int opcao = LerInt();
                if (!OpcaoEhValida(opcao))
                {
                    ImprimirMensagem("Voce digitou uma opcao invalida!", TipoMensagem.ERRO);
                    continue;
                }

                return opcao;
            }
        }

        private bool OpcaoEhValida(int op)
        {
            //Opcao voltar
            if (op == opcaoAtual)
                return true;

            foreach (OpcaoTela opcao in opcoes)
            {
                if (opcao.N == op)
                    return true;
            }

            return false;
        }

        private TelaBase EncontrarOpcao(int op)
        {
            //opcao voltar
            if (op == opcaoAtual)
                return new OpcaoVoltar();

            foreach (OpcaoTela opcao in opcoes)
            {
                if (opcao.N == op)
                    return opcao.Menu;
            }
            return null;
        }

    }
}
