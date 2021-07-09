using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Query.Campos;

namespace ControleDeTarefas.Query
{
    abstract public class Modelo
    {
        public List<CampoBase> campos = new List<CampoBase>();

        abstract public string NomeTabela { get; }
        abstract public string NomeFormal { get; }

        public Campo<int> campoId;

        public int Id { get => campoId.Valor; set => campoId.Valor = value; }

        protected Modelo()
        {
            campoId = new Campo<int>("Id");
            campoId.modeloRef = this;
        }

        protected Modelo(string nomeCampoId)
        {
            campoId = new Campo<int>(nomeCampoId);
            campoId.modeloRef = this;
        }

        protected Campo<T> Campo<T>(string nome, T valor = default)
        {
            Campo<T> campo = new Campo<T>(nome, valor, this);

            campos.Add(campo);

            return campo;
        }

        protected CampoRelacionavel<T> CampoRelacionavel<T>(string nome, T valor = default) 
            where T : Modelo
        {
            CampoRelacionavel<T> campo = new CampoRelacionavel<T>(nome, valor, this);

            campos.Add(campo);

            return campo;
        }
    }
}
