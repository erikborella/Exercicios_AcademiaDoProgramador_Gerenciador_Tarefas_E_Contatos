using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Geradores.Shared.ElementosGeraveis
{
    internal class OperadorLogicoGeravel : AtributoGeravel
    {
        internal enum TipoJuncao
        {
            AND,
            OR,
            NOT
        }

        internal TipoJuncao tipoJuncao;

        internal OperadorLogicoGeravel(TipoJuncao tipoJuncao)
        {
            this.tipoJuncao = tipoJuncao;
        }

        internal override string Gerar()
        {
            return tipoJuncao.ToString();
        }
    }

}
