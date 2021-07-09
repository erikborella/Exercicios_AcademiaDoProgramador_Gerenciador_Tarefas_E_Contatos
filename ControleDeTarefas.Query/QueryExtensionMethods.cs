using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ControleDeTarefas.Query.Geradores;

namespace ControleDeTarefas.Query
{
    public static class QueryExtensionMethods
    {
        public static GeradorSqlTipoConsulta SQL(this Modelo modelo)
        {
            return new GeradorSqlTipoConsulta(modelo);
        }
    }
}
