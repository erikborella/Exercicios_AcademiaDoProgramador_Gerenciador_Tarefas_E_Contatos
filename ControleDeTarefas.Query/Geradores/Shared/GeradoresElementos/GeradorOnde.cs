using ControleDeTarefas.Query.Geradores.Shared.ElementosGeraveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Geradores.Shared.GeradoresElementos
{
    class GeradorOnde<T> : AtributoGeravel
        where T : GeradorBase
    {
        List<AtributoGeravel> expressoes = new List<AtributoGeravel>();

        internal T geradorParaContinuar;

        public GeradorOnde(T geradorParaContinuar)
        {
            this.geradorParaContinuar = geradorParaContinuar;
        }

        public ComparasaoGeravel<T> AdicionarOnde(string campo)
        {
            ComparasaoGeravel<T> where =
                new ComparasaoGeravel<T>(geradorParaContinuar, campo);

            expressoes.Add(where);

            return where;
        }

        public ComparasaoGeravel<T> AdicionarNaoOnde(string campo)
        {
            expressoes.Add(new OperadorLogicoGeravel(OperadorLogicoGeravel.TipoJuncao.NOT));
            return AdicionarOnde(campo);
        }

        public void AdicionarE()
        {
            expressoes.Add(new OperadorLogicoGeravel(OperadorLogicoGeravel.TipoJuncao.AND));
        }

        public void AdicionarOu()
        {
            expressoes.Add(new OperadorLogicoGeravel(OperadorLogicoGeravel.TipoJuncao.OR));
        }

        private string GerarExpressoes()
        {
            if (expressoes.Count == 0)
                return "";

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("WHERE");

            for (int i = 0; i < expressoes.Count; i++)
            {
                AtributoGeravel atributoGeravel = expressoes[i];

                sql.Append(atributoGeravel.Gerar());

                if (i != expressoes.Count - 1)
                    sql.AppendLine();
            }

            return sql.ToString();

        }

        internal override string Gerar()
        {
            return GerarExpressoes();
        }
    }
}
