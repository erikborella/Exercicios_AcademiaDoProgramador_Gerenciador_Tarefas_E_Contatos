using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas;
using System.Collections.Generic;
using System;
using ControleDeTarefas.Controladores;
using ControleDeTarefas.Query;

using System.Configuration;
using ControleDeTarefas.Dominios.Modelos;

namespace ControleDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            ExecutarMenu(telaPrincipal);

            ContatoModelo contato = new ContatoModelo("asdasd", "asdsdsd", "23123", "231", "31231");


            string sql = contato
                .SQL()
                .Selecionar()
                .TodosOsCampos()
                .Onde(contato.campoNome).EhIgualA("12313");

            Console.WriteLine(sql);

        }

        private static void ExecutarMenu(TelaBase tela)
        {
            while (true)
            {
                TelaBase proximaTela = tela.Executar();

                if (proximaTela is OpcaoVoltar || proximaTela == null)
                    break;

                ExecutarMenu(proximaTela);
            }
        }

    }
}
