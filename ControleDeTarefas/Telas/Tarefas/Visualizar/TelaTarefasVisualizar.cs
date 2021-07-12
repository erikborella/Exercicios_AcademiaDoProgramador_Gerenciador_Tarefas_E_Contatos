using ControleDeTarefas.Controladores.Legado;

namespace ControleDeTarefas.Telas.Tarefas.Visualizar
{
    class TelaTarefasVisualizar : TelaTarefas
    {
        public TelaTarefasVisualizar(ControladorTarefa controladorTarefa)
            : base("Visualizar Tarefas", controladorTarefa)
        {
            AdicionarOpcao(new TelaTarefasVisualizarTodas(controladorTarefa));
            AdicionarOpcao(new TelaTarefasVisualizarPendentes(controladorTarefa));
            AdicionarOpcao(new TelaTarefasVisualizarConcluidas(controladorTarefa));
        }

        protected TelaTarefasVisualizar(string descricao, ControladorTarefa controladorTarefa)
            : base(descricao, controladorTarefa)
        {
        }
    }
}
