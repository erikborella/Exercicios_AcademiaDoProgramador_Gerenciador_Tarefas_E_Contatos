using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas.Contatos;

namespace ControleDeTarefas.Telas.Compromissos.Visualizar
{
    class TelaCompromissosVisualizarTodos : TelaCompromissos
    {
        public TelaCompromissosVisualizarTodos(ControladorCompromisso controladorCompromisso, 
            TelaContatos telaContatos) :
            base("Visualizar todos", controladorCompromisso, telaContatos)
        { 
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            VisualizarTodosCompromissos();

            Pausar();
            return null;
        }
    }
}
