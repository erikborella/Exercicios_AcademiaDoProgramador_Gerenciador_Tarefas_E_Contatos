using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Geradores.Shared.Apelidos;

namespace ControleDeTarefas.Query.Geradores.Shared.ElementosGeraveis
{
    public class JuncaoGeravel<T> : AtributoGeravel
        where T : GeradorBase
    {
        internal enum TipoJuncao
        {
            ESQUERDA,
            DIREITA,
            INTERNA,
            EXTERNA
        }

        internal T geradorParaContinuar;

        internal GeradorApelidoTabela geradorApelido;

        internal CampoRelacionavelBase campoRelacionavel;
        internal TipoJuncao tipoJuncao;

        internal JuncaoGeravel(T geradorParaContinuar, GeradorApelidoTabela geradorApelido,
            CampoRelacionavelBase campoRelacionavel)
        {
            this.geradorParaContinuar = geradorParaContinuar;
            this.campoRelacionavel = campoRelacionavel;

            this.geradorApelido = geradorApelido;
        }

        public T JuncaoEsquerda()
        {
            tipoJuncao = TipoJuncao.ESQUERDA;
            return geradorParaContinuar;
        }

        public T JuncaoDireita()
        {
            tipoJuncao = TipoJuncao.DIREITA;
            return geradorParaContinuar;
        }
        public T JuncaoInterna()
        {
            tipoJuncao = TipoJuncao.INTERNA;
            return geradorParaContinuar;
        }
        public T JuncaoExterna()
        {
            tipoJuncao = TipoJuncao.EXTERNA;
            return geradorParaContinuar;
        }

        private string PegarJuncao()
        {
            switch (tipoJuncao)
            {
                case TipoJuncao.ESQUERDA:
                    return "LEFT JOIN";
                case TipoJuncao.DIREITA:
                    return "RIGHT JOIN";
                case TipoJuncao.INTERNA:
                    return "INNER JOIN";
                case TipoJuncao.EXTERNA:
                    return "FULL OUTER JOIN";
            }

            return "";
        }

        private string GerarFROM()
        {
            StringBuilder sqlFROM = new StringBuilder();

            string nomeTabela1 = campoRelacionavel.modeloRef.NomeTabela;
            string apelidoTabela1 = geradorApelido[campoRelacionavel.modeloRef];

            string nomeTabela2 = campoRelacionavel.Valor.NomeTabela;
            string apelidoTabela2 = geradorApelido[campoRelacionavel.Valor];

            sqlFROM.AppendLine("FROM");

            sqlFROM.AppendLine($"[{nomeTabela1}] [{apelidoTabela1}]");
            sqlFROM.AppendLine(PegarJuncao());
            sqlFROM.AppendLine($"[{nomeTabela2}] [{apelidoTabela2}]");

            return sqlFROM.ToString();
        }

        private string GerarON()
        {
            StringBuilder sqlON = new StringBuilder();

            string apelidoTabela1 = geradorApelido[campoRelacionavel.modeloRef];
            string campoParaCompararTabela1 = campoRelacionavel.Nome;

            string apelidoTabela2 = geradorApelido[campoRelacionavel.Valor];
            string campoParaCompararTabela2 = campoRelacionavel.Valor.campoId.Nome;

            sqlON.AppendLine("ON");

            sqlON.Append($"[{apelidoTabela1}].[{campoParaCompararTabela1}]");
            sqlON.Append(" = ");
            sqlON.AppendLine($"[{apelidoTabela2}].[{campoParaCompararTabela2}]");

            return sqlON.ToString();
        }

        internal override string Gerar()
        {
            StringBuilder sqlJOIN = new StringBuilder();

            sqlJOIN.Append(GerarFROM());
            sqlJOIN.Append(GerarON());

            return sqlJOIN.ToString();
        }
    }
}
