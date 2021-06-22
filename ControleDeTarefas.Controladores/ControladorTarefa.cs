using ControleDeTarefas.Dominios;
using System;
using System.Data.SqlClient;

namespace ControleDeTarefas.Controladores
{
    public class ControladorTarefa : ControladorBase<Tarefa>
    {
        public ControladorTarefa() : base("TBTarefa")
        {
        }

        public bool AtualizarPercentualConcluido(int id, int percentual)
        {
            string[] campos = { "percentualconcluido" };

            if (percentual == 100)
                ConcluirTarefa(id);

            Tarefa temp = new Tarefa(id, percentual);

            return Editar(temp, campos);
        }

        protected override string[] PegarCamposEditar()
        {
            string[] campos =
            {
                "titulo",
                "prioridade"
            };

            return campos;
        }

        protected override string[] PegarCamposInserir()
        {
            string[] campos =
            {
                "titulo",
                "datacriacao",
                "percentualconcluido",
                "prioridade"
            };

            return campos;
        }

        protected override Tarefa LerRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["Id"]);
            string titulo = Convert.ToString(leitor["titulo"]);
            DateTime dataCriacao = Convert.ToDateTime(leitor["dataCriacao"]);
            DateTime? dataConclusao = PegarDataConclusao(leitor);
            int percentualConcluido = Convert.ToInt32(leitor["percentualConcluido"]);
            PrioridadeTarefa prioridade = PegarPrioridade(leitor);

            return new Tarefa(id, titulo, dataCriacao, dataConclusao, percentualConcluido, prioridade);
        }

        private void ConcluirTarefa(int id)
        {
            DateTime dataConclusao = DateTime.Now;
            string[] campos = { "dataconclusao" };

            Tarefa temp = new Tarefa(id, dataConclusao);

            Editar(temp, campos);
        }

        private PrioridadeTarefa PegarPrioridade(SqlDataReader leitor)
        {
            int nPrioridade = Convert.ToInt32(leitor["prioridade"]);

            PrioridadeTarefa prioridade;

            switch (nPrioridade)
            {
                case 1:
                    prioridade = PrioridadeTarefa.BAIXA;
                    break;

                case 2:
                    prioridade = PrioridadeTarefa.MEDIA;
                    break;

                case 3:
                    prioridade = PrioridadeTarefa.ALTA;
                    break;

                default:
                    prioridade = PrioridadeTarefa.BAIXA;
                    break;
            }

            return prioridade;
        }

        private DateTime? PegarDataConclusao(SqlDataReader leitor)
        {
            object dataConclusao = leitor["dataConclusao"];

            if (dataConclusao == DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(dataConclusao);
        }
    }
}
