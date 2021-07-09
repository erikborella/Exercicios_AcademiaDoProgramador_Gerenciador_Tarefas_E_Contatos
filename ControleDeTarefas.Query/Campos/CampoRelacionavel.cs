using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Campos
{
    public class CampoRelacionavel<T> : CampoRelacionavelBase
        where T : Modelo
    {
        new public T Valor { get => (T) valor; set => valor = value; }

        internal CampoRelacionavel(string nome, T valor = null, Modelo modeloRef = null) 
            : base(nome, valor, modeloRef)
        {
        }
    }
}
