using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Dominios.Base
{
    abstract public class DominioBaseRelacionado<T> : DominioBase
        where T : DominioBase
    {
        public T DominioEstrangeiro { get; set; }
    }
}
