using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query.Geradores.Atualizar;
using ControleDeTarefas.Query.Geradores.Inserir;
using ControleDeTarefas.Query.Geradores.Deletar;
using ControleDeTarefas.Query.Geradores.Selecionar;

namespace ControleDeTarefas.Query.Geradores
{
    public class GeradorSqlTipoConsulta
    {
        private Modelo modelo;

        public GeradorSqlTipoConsulta(Modelo modelo)
        {
            this.modelo = modelo;
        }

        public GeradorSqlInserirCampos Inserir()
        {
            return new GeradorSqlInserirCampos(modelo);
        }

        public GeradorSqlAtualizarCampos Atualizar()
        {
            return new GeradorSqlAtualizarCampos(modelo);
        }

        public GeradorSqlDeletar Deletar()
        {
            return new GeradorSqlDeletar(modelo);
        }

        public GeradorSqlSelecionarCampos Selecionar()
        {
            return new GeradorSqlSelecionarCampos(modelo);
        }
    }

}
