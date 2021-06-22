using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas.Tarefas.Visualizar;
using System;
using System.Linq;

namespace ControleDeTarefas.Telas.Tarefas
{
    class TelaTarefas : TelaBase
    {
        protected ControladorTarefa controladorTarefa;

        public TelaTarefas(ControladorTarefa controladorTarefa) : base("Tarefas")
        {
            this.controladorTarefa = controladorTarefa;

            AdicionarOpcao(new TelaTarefasCriar(controladorTarefa));
            AdicionarOpcao(new TelaTarefasEditar(controladorTarefa));
            AdicionarOpcao(new TelaTarefasExcluir(controladorTarefa));
            AdicionarOpcao(new TelaTarefasAlterarProgresso(controladorTarefa));
            AdicionarOpcao(new TelaTarefasVisualizar(controladorTarefa));
        }

        protected TelaTarefas(string descricao, ControladorTarefa controladorTarefa)
            : base(descricao)
        {
            this.controladorTarefa = controladorTarefa;
        }

        protected Tarefa ObterTarefa()
        {
            ImprimirMensagem("Digite o titulo: ", TipoMensagem.INPUT);
            string titulo = LerString();

            Console.WriteLine();

            PrioridadeTarefa prioridade = LerPrioridade();

            return new Tarefa(titulo, prioridade);
        }

        protected int ObterIdTarefa(Tarefa[] tarefas)
        {
            VisualizarTarefas(tarefas);
            Console.WriteLine();

            ImprimirMensagem("Digite o id da tarefa que deseja selecionar: ", TipoMensagem.INPUT);
            int id = LerInt();

            if (!ExisteTarefaComId(tarefas, id))
                return -1;
            else
                return id;
        }

        protected int ObterIdTarefa()
        {
            Tarefa[] tarefas = controladorTarefa
                .BuscarRegistros()
                .OrderByDescending(tarefa => tarefa.Prioridade)
                .ToArray();

            return ObterIdTarefa(tarefas);
        }

        protected void VisualizarTarefas(Tarefa[] tarefas)
        {
            string template = "{0, -3} | {1, -20} | {2, -20} | {3, -20} | {4, -10} | {5, -10}";

            Console.WriteLine(template,
                "id", "Titulo", "Data criação", "Data conclusão", "Progresso", "Prioridade");
            Console.WriteLine();

            if (tarefas.Length == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada");
                return;
            }

            foreach (Tarefa tarefa in tarefas)
            {
                Console.WriteLine(template,
                    tarefa.Id,
                    tarefa.Titulo,
                    tarefa.DataCriacao,
                    tarefa.DataConclusao,
                    $"{tarefa.PercentualConcluido}%",
                    tarefa.Prioridade);
            }
        }

        protected void VisualizarTodasTarefas()
        {
            Tarefa[] tarefas = controladorTarefa
                .BuscarRegistros()
                .OrderByDescending(tarefa => tarefa.Prioridade)
                .ToArray();

            VisualizarTarefas(tarefas);
        }

        private PrioridadeTarefa LerPrioridade()
        {
            Console.WriteLine("Defina a prioridade da tarefa:");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Media");
            Console.WriteLine("3. Baixa");
            Console.WriteLine();

            ImprimirMensagem("Escolha a prioridade: ", TipoMensagem.INPUT);

            int nPrioridade = LerNoIntervalo(1, 3);
            PrioridadeTarefa prioridade;

            switch (nPrioridade)
            {
                case 1:
                    prioridade = PrioridadeTarefa.ALTA;
                    break;

                case 2:
                    prioridade = PrioridadeTarefa.MEDIA;
                    break;

                case 3:
                    prioridade = PrioridadeTarefa.BAIXA;
                    break;

                default:
                    prioridade = PrioridadeTarefa.BAIXA;
                    break;
            }

            return prioridade;
        }

        private bool ExisteTarefaComId(Tarefa[] tarefas, int id)
        {
            return tarefas.FirstOrDefault(tarefa => tarefa.Id == id) != null;
        }

    }

}
