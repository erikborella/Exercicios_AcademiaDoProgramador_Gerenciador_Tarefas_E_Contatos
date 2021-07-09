using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Geradores
{
    abstract public class GeradorBase
    {
        public Modelo modelo;

        abstract public string ToSQL();

        public override string ToString()
        {
            return ToSQL();
        }

        public static implicit operator string(GeradorBase g)
        {
            return g.ToSQL();
        }
    }
}
