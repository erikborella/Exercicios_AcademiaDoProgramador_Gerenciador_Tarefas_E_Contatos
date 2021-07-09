using ControleDeTarefas.Query.Campos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Geradores.Selecionar
{
    public class GeradorSqlSelecionarCampos : GeradorBase
    {
        public GeradorSqlSelecionarCampos(Modelo modelo)
        {
            this.modelo = modelo;
        }

        public GeradorSqlSelecionar TodosOsCampos()
        {
            List<CampoBase> campos = new List<CampoBase>();

            campos.Add(modelo.campoId);
            campos.AddRange(modelo.campos);
            
            return new GeradorSqlSelecionar(modelo, campos.ToArray());
        }

        public GeradorSqlSelecionar Campos(params CampoBase[] camposParaSelecionar)
        {
            return new GeradorSqlSelecionar(modelo, camposParaSelecionar);
        }

        public GeradorSqlSelecionar TodosOsCamposDe(params Modelo[] modelosParaSelecionar)
        {
            List<CampoBase> campos = new List<CampoBase>();


            foreach (Modelo modelo in modelosParaSelecionar)
            {
                campos.Add(modelo.campoId);
                campos.AddRange(modelo.campos);
            }

            return new GeradorSqlSelecionar(modelo, campos.ToArray());
        }


        public override string ToSQL()
        {
            throw new ApplicationException("Tens que informar os campos que deseja selecionar");
        }
    }
}
