using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Geradores.Shared;

namespace ControleDeTarefas.Query.Geradores.Atualizar
{
    public class GeradorSqlAtualizarCampos : GeradorBase
    {
        public GeradorSqlAtualizarCampos(Modelo modelo)
        {
            this.modelo = modelo;
        }

        public GeradorSqlAtualizar TodosOsCampos()
        {
            return new GeradorSqlAtualizar(modelo, modelo.campos.ToArray());
        }

        public GeradorSqlAtualizar Campos(params CampoBase[] camposParaEditar)
        {
            return new GeradorSqlAtualizar(modelo, camposParaEditar);
        }

        public override string ToSQL()
        {
            throw new ApplicationException("Tens que informar os campos que deseja editar");
        }
    }
}
