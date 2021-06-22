using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Contatos
{
    class TelaContatosVisualizar : TelaContatos
    {

        public TelaContatosVisualizar(ControladorContato controladorContato)
            : base("Visualizar contatos", controladorContato)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            VisualizarTodosContatos();

            Pausar();
            return null;
        }
    }
}
