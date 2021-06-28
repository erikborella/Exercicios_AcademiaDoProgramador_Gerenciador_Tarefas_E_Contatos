using ControleDeTarefas.Dominios.Base;
using System;

namespace ControleDeTarefas.Dominios
{
    public class Tarefa : DominioBase
    {
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int PercentualConcluido { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }

        public Tarefa(int id, int percentualConcluido)
        {
            Id = id;
            PercentualConcluido = percentualConcluido;
        }

        public Tarefa(int id, DateTime? dataConclusao)
        {
            Id = id;
            DataConclusao = dataConclusao;
        }

        public Tarefa(string titulo, PrioridadeTarefa prioridade)
        {
            Titulo = titulo;
            DataCriacao = DateTime.Now;
            PercentualConcluido = 0;
            Prioridade = prioridade;
        }

        public Tarefa(int id, string titulo, DateTime dataCriacao, DateTime? dataConclusao, int percentualConcluido, PrioridadeTarefa prioridade)
        {
            Id = id;
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            PercentualConcluido = percentualConcluido;
            Prioridade = prioridade;
        }
    }
}
