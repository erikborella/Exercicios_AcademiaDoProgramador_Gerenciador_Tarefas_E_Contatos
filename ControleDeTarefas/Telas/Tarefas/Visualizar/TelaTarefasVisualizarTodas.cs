using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Tarefas.Visualizar
{
    class TelaTarefasVisualizarTodas : TelaTarefasVisualizar
    {
        public TelaTarefasVisualizarTodas(ControladorTarefa controladorTarefa)
            : base("Visualizar Todas As Tarefas", controladorTarefa)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            VisualizarTodasTarefas();

            Pausar();

            return null;
        }
    }
}
