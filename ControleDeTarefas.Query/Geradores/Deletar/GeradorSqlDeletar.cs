using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Geradores.Shared.ElementosGeraveis;
using ControleDeTarefas.Query.Geradores.Shared.GeradoresElementos;

namespace ControleDeTarefas.Query.Geradores.Deletar
{
    public class GeradorSqlDeletar : GeradorBase
    {
        private GeradorOnde<GeradorSqlDeletar> geradorOnde;
        
        public GeradorSqlDeletar(Modelo modelo)
        {
            this.modelo = modelo;

            this.geradorOnde = new GeradorOnde<GeradorSqlDeletar>(this);
        }

        public GeradorSqlDeletar NoMesmoId()
        {
            geradorOnde.AdicionarOnde(modelo.campoId.Nome).EhIgualA(modelo.Id);
            return this;
        }

        public ComparasaoGeravel<GeradorSqlDeletar> Onde(string campo)
        {
            return geradorOnde.AdicionarOnde(campo);
        }

        public ComparasaoGeravel<GeradorSqlDeletar> Onde(CampoBase campo)
        {
            return Onde(campo.nome);
        }

        public ComparasaoGeravel<GeradorSqlDeletar> NaoOnde(string campo)
        {
            return geradorOnde.AdicionarNaoOnde(campo);
        }

        public ComparasaoGeravel<GeradorSqlDeletar> NaoOnde(CampoBase campo)
        {
            return NaoOnde(campo.nome);
        }

        public GeradorSqlDeletar E()
        {
            geradorOnde.AdicionarE();
            return this;
        }

        public GeradorSqlDeletar Ou()
        {
            geradorOnde.AdicionarOu();
            return this;
        }

        private string GerarDELETE()
        {
            return $"DELETE FROM [{modelo.NomeTabela}]";
        }

        private string Gerar()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(GerarDELETE());
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
