using ControleDeTarefas.Query.Campos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Query.Geradores.Inserir
{
    public class GeradorSqlInserirCampos : GeradorBase
    {
        public GeradorSqlInserirCampos(Modelo modelo)
        {
            this.modelo = modelo;
        }

        public GeradorSqlInserir TodosOsCampos()
        {
            return new GeradorSqlInserir(modelo, modelo.campos.ToArray());
        }

        public GeradorSqlInserir Campos(params CampoBase[] camposParaInserir)
        {
            return new GeradorSqlInserir(modelo, camposParaInserir);
        }

        public override string ToSQL()
        {
            throw new ApplicationException("Tens que informar os campos que deseja inserir");
        }
    }
}
