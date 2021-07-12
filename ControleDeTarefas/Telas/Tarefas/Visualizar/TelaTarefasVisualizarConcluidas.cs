using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;
using System.Linq;

namespace ControleDeTarefas.Telas.Tarefas.Visualizar
{
    class TelaTarefasVisualizarConcluidas : TelaTarefasVisualizar
    {
        public TelaTarefasVisualizarConcluidas(ControladorTarefa controladorTarefa)
            : base("Visualizar Tarefas Concluidas", controladorTarefa)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            Tarefa[] tarefas = controladorTarefa.BuscarRegistros();

            Tarefa[] tarefasConcluidas = tarefas
                .Where(tarefa => tarefa.PercentualConcluido == 100)
                .OrderByDescending(tarefa => tarefa.Prioridade)
                .ToArray();

            VisualizarTarefas(tarefasConcluidas);

            Pausar();
            return null;
        }
    }
}
