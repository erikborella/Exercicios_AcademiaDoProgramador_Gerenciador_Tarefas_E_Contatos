using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;
using System.Linq;

namespace ControleDeTarefas.Telas.Tarefas
{
    class TelaTarefasAlterarProgresso : TelaTarefas
    {
        public TelaTarefasAlterarProgresso(ControladorTarefa controladorTarefa)
            : base("Alterar Progesso de uma tarefa", controladorTarefa)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            Tarefa[] tarefasPendentes = controladorTarefa
                .BuscarRegistros()
                .Where(tarefa => tarefa.PercentualConcluido != 100)
                .OrderByDescending(tarefa => tarefa.Prioridade)
                .ToArray();

            int id = ObterIdTarefa(tarefasPendentes);

            if (IdNaoEncontrado(id))
            {
                ImprimirMensagem("O id digitado não corresponde a nenhuma tarefa", TipoMensagem.ERRO);
                Pausar();
                return null;
            }

            int novoPercentual = LerPercentual();

            bool conseguiuMudar = controladorTarefa.AtualizarPercentualConcluido(id, novoPercentual);

            if (conseguiuMudar)
                ImprimirMensagem("Progresso da tarefa alterado com successo", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao alterar a porcentagem da tarefa", TipoMensagem.ERRO);

            Pausar();

            return null;
        }

        private static bool IdNaoEncontrado(int id)
        {
            return id == -1;
        }

        private int LerPercentual()
        {
            ImprimirMensagem("Digite o quanto da tarefa já está concluida (0 - 100): ", TipoMensagem.INPUT);
            int porcentagem = LerNoIntervalo(0, 100);

            return porcentagem;
        }


    }
}
