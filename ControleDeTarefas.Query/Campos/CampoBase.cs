using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Campos
{
    public abstract class CampoBase
    {
        internal object valor;
        internal string nome;

        internal Modelo modeloRef;

        internal CampoBase()
        {

        }
    }
}
