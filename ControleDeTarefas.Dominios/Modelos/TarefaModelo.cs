using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Interfaces;

namespace ControleDeTarefas.Dominios
{
    public class TarefaModelo : Modelo, IModeloConvertivel<TarefaModelo>
    {

        public Campo<string> campoTitulo;
        public Campo<DateTime> campoDataCriacao;
        public Campo<DateTime?> campoDataConclusao;
        public Campo<int> campoPercentualConcluido;
        public Campo<PrioridadeTarefa> campoPrioridade;

        public string Titulo { get => campoTitulo.Valor; set => campoTitulo.Valor = value; }
        public DateTime DataCriacao { get => campoDataCriacao.Valor; set => campoDataCriacao.Valor = value; }
        public DateTime? DataConclusao { get => campoDataConclusao.Valor; set => campoDataConclusao.Valor = value; }
        public int PercentualConcluido { get => campoPercentualConcluido.Valor; set => campoPercentualConcluido.Valor = value; }
        public PrioridadeTarefa Prioridade { get => campoPrioridade.Valor; set => campoPrioridade.Valor = value; }

        public TarefaModelo()
        {
            IniciarCampos();
        }
        public TarefaModelo(int id, DateTime? dataConclusao)
        {
            IniciarCampos();

            Id = id;
            DataConclusao = dataConclusao;
        }

        public TarefaModelo(string titulo, PrioridadeTarefa prioridade)
        {
            IniciarCampos();

            Titulo = titulo;
            DataCriacao = DateTime.Now;
            PercentualConcluido = 0;
            Prioridade = prioridade;
        }

        public TarefaModelo(int id, string titulo, DateTime dataCriacao, DateTime? dataConclusao, int percentualConcluido, PrioridadeTarefa prioridade)
        {
            IniciarCampos();

            Id = id;
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            PercentualConcluido = percentualConcluido;
            Prioridade = prioridade;
        }

        public override string NomeTabela => "TBTarefa";
        public override string NomeFormal => "Tarefa";


        private void IniciarCampos()
        {
            campoTitulo = Campo<string>("titulo");
            campoDataCriacao = Campo<DateTime>("dataCriacao");
            campoDataConclusao = Campo<DateTime?>("dataConclusao");
            campoPercentualConcluido = Campo<int>("percentualConcluido");
            campoPrioridade = Campo<PrioridadeTarefa>("prioridade");
        }

        public TarefaModelo Converter(Dictionary<string, object> valores)
        {
            int id = 0;
            string titulo = null;
            DateTime dataCriacao = default;
            DateTime? dataConclusao = default;
            int percentualConcluido = 0;
            PrioridadeTarefa prioridade = default;

            if (valores.ContainsKey("Id"))
                id = Convert.ToInt32(valores["Id"]);

            if (valores.ContainsKey("titulo"))
                titulo = Convert.ToString(valores["titulo"]);

            if (valores.ContainsKey("dataCriacao"))
                dataCriacao = Convert.ToDateTime(valores["dataCriacao"]);

            if (valores.ContainsKey("dataConclusao") && valores["dataConclusao"] != DBNull.Value)
                dataConclusao = Convert.ToDateTime(valores["dataConclusao"]);

            if (valores.ContainsKey("percentualConcluido"))
                percentualConcluido = Convert.ToInt32(valores["percentualConcluido"]);

            if (valores.ContainsKey("prioridade"))
                prioridade = PegarPrioridade(Convert.ToInt32(valores["prioridade"]));

            return new TarefaModelo(id, titulo, dataCriacao, dataConclusao, percentualConcluido, prioridade);
        }

        private PrioridadeTarefa PegarPrioridade(int nPrioridade)
        {
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
    }
}
