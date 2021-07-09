using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Interfaces
{
    public interface IModeloConvertivel<T> where T : Modelo
    {
        T Converter(Dictionary<string, object> valores);
    }
}
