using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;
using System.Linq;

namespace ControleDeTarefas.Telas.Tarefas.Visualizar
{
    class TelaTarefasVisualizarPendentes : TelaTarefasVisualizar
    {
        public TelaTarefasVisualizarPendentes(ControladorTarefa controladorTarefa)
            : base("Visualiar Tarefas Pendentes", controladorTarefa)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            TarefaModelo[] tarefas = controladorTarefa.BuscarRegistros();

            TarefaModelo[] tarefasPendentes = tarefas
                .Where(tarefa => tarefa.PercentualConcluido != 100)
                .OrderByDescending(tarefa => tarefa.Prioridade)
                .ToArray();

            VisualizarTarefas(tarefasPendentes);
            Pausar();

            return null;
        }
    }
}
