using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Geradores.Shared;

namespace ControleDeTarefas.Query.Geradores.Inserir
{
    public class GeradorSqlInserir : GeradorBase
    {
        private CampoBase[] camposParaInserir;
        public GeradorSqlInserir(Modelo modelo, params CampoBase[] camposParaInserir)
        {
            this.modelo = modelo;
            this.camposParaInserir = camposParaInserir;
        }

        private string Gerar()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"INSERT INTO [{modelo.NomeTabela}]");
            sql.AppendLine("(");

            for (int i = 0; i < camposParaInserir.Length; i++)
            {
                sql.Append($"[{camposParaInserir[i].nome}]");

                if (i != camposParaInserir.Length - 1)
                    sql.Append(",");

                sql.AppendLine();
            }

            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");

            for (int i = 0; i < camposParaInserir.Length; i++)
            {
                sql.Append(Utils.PegarValorParaDB(camposParaInserir[i]));

                if (i != camposParaInserir.Length - 1)
                    sql.Append(",");

                sql.AppendLine();
            }

            sql.AppendLine(");");

            return sql.ToString();
        }

        public override string ToSQL()
        {
            return Gerar();
        }
    }

}
