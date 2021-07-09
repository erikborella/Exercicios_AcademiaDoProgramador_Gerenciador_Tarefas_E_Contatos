using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Geradores.Shared;
using ControleDeTarefas.Query.Geradores.Shared.ElementosGeraveis;
using ControleDeTarefas.Query.Geradores.Shared.GeradoresElementos;

namespace ControleDeTarefas.Query.Geradores.Atualizar
{
    public class GeradorSqlAtualizar : GeradorBase
    {
        private CampoBase[] camposParaEditar;

        private GeradorOnde<GeradorSqlAtualizar> geradorOnde;

        public GeradorSqlAtualizar(Modelo modelo, params CampoBase[] camposParaEditar)
        {
            this.camposParaEditar = camposParaEditar;
            this.modelo = modelo;

            this.geradorOnde = new GeradorOnde<GeradorSqlAtualizar>(this);
        }

        public GeradorSqlAtualizar NoMesmoId()
        {
            geradorOnde.AdicionarOnde(modelo.campoId.Nome).EhIgualA(modelo.Id);
            return this;
        }
        public ComparasaoGeravel<GeradorSqlAtualizar> Onde(string campo)
        {
            return geradorOnde.AdicionarOnde(campo);
        }

        public ComparasaoGeravel<GeradorSqlAtualizar> Onde(CampoBase campo)
        {
            return Onde(campo.nome);
        }

        public ComparasaoGeravel<GeradorSqlAtualizar> NaoOnde(string campo)
        {
            return geradorOnde.AdicionarNaoOnde(campo);
        }

        public ComparasaoGeravel<GeradorSqlAtualizar> NaoOnde(CampoBase campo)
        {
            return NaoOnde(campo.nome);
        }


        public GeradorSqlAtualizar E()
        {
            geradorOnde.AdicionarE();
            return this;
        }

        public GeradorSqlAtualizar Ou()
        {
            geradorOnde.AdicionarOu();
            return this;
        }

        private string GerarUPDATE()
        {
            StringBuilder sqlUPDATE = new StringBuilder();

            sqlUPDATE.AppendLine($"UPDATE [{modelo.NomeTabela}]");
            sqlUPDATE.AppendLine("SET");

            for (int i = 0; i < camposParaEditar.Length; i++)
            {
                CampoBase campo = camposParaEditar[i];

                sqlUPDATE.Append($"[{campo.nome}] = {Utils.PegarValorParaDB(campo)}");

                if (i != camposParaEditar.Length - 1)
                    sqlUPDATE.Append(",");

                sqlUPDATE.AppendLine();
            }

            return sqlUPDATE.ToString();
        }

        private string Gerar()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(GerarUPDATE());
            sql.Append(geradorOnde.Gerar());

            sql.Append(";");

            return sql.ToString();
        }

        public override string ToSQL()
        {
            return Gerar();
        }
    }

}
