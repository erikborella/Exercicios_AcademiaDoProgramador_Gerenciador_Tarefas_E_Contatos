using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Campos
{
    public class CampoRelacionavelBase : CampoBase
    {
        public Modelo Valor { get => (Modelo)valor; set => valor = value; }
        public string Nome { get => nome; set => nome = value; }

        internal CampoRelacionavelBase(string nome, Modelo valor = null, Modelo modeloRef = null)
        {
            Valor = valor;
            Nome = nome;
            this.modeloRef = modeloRef;
        }
    }
}
