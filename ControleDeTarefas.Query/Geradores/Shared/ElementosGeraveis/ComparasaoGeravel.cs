using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Geradores.Shared.ElementosGeraveis
{
    public class ComparasaoGeravel<T> : AtributoGeravel
        where T : GeradorBase
    {
        internal enum TipoComparacao
        {
            IGUAL,
            DIFERENTE,
            MAIOR,
            MAIOR_OU_IGUAL,
            MENOR,
            MENOR_OU_IGUAl
        }

        internal T geradorParaContinuar;

        internal string campo;
        internal TipoComparacao tipoComparacao;
        internal object valor;

        internal ComparasaoGeravel(T geradorParaContinuar, string campo)
        {
            this.geradorParaContinuar = geradorParaContinuar;
            this.campo = campo;
        }

        public T EhIgualA(object valor)
        {
            tipoComparacao = TipoComparacao.IGUAL;
            this.valor = valor;
            return geradorParaContinuar;
        }

        public T EhDiferenteDe(object valor)
        {
            tipoComparacao = TipoComparacao.DIFERENTE;
            this.valor = valor;
            return geradorParaContinuar;
        }

        public T EhMaiorQue(object valor)
        {
            tipoComparacao = TipoComparacao.MAIOR;
            this.valor = valor;
            return geradorParaContinuar;
        }

        public T EhMaiorOuIgualA(object valor)
        {
            tipoComparacao = TipoComparacao.MAIOR_OU_IGUAL;
            this.valor = valor;
            return geradorParaContinuar;
        }
        public T EhMenorQue(object valor)
        {
            tipoComparacao = TipoComparacao.MENOR;
            this.valor = valor;
            return geradorParaContinuar;
        }

        public T EhMenorOuIgualA(object valor)
        {
            tipoComparacao = TipoComparacao.MENOR_OU_IGUAl;
            this.valor = valor;
            return geradorParaContinuar;
        }

        private string PegarSimboloComparacao()
        {
            switch (tipoComparacao)
            {
                case TipoComparacao.IGUAL:
                    return "=";
                case TipoComparacao.DIFERENTE:
                    return "<>";
                case TipoComparacao.MAIOR:
                    return ">";
                case TipoComparacao.MAIOR_OU_IGUAL:
                    return ">=";
                case TipoComparacao.MENOR:
                    return "<";
                case TipoComparacao.MENOR_OU_IGUAl:
                    return "<=";
            }

            return "";
        }

        internal override string Gerar()
        {
            string simboloComparacao = PegarSimboloComparacao();

            return $"{campo} {simboloComparacao} {Utils.PegarValorParaDB(valor)}";
        }
    }

}
