using ControleDeTarefas.Dominios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.Tarefas
{
    public partial class TelaCriarTarefa : Form
    {
        public Tarefa TarefaCriada { get; private set; }

        public TelaCriarTarefa()
        {
            InitializeComponent();

        }

        public TelaCriarTarefa(Tarefa tarefa)
        {
            InitializeComponent();

            TarefaCriada = tarefa;

            text_titulo.Text = tarefa.Titulo;
            cb_prioridade.SelectedIndex = ((int)tarefa.Prioridade) - 1;
        }
  
        private void MontarTarefa()
        {
            string titulo = text_titulo.Text;
            PrioridadeTarefa prioridade = PegarPrioridadeBaseadaNoIndex(
                cb_prioridade.SelectedIndex);

            Tarefa novaTarefa = new Tarefa(titulo, prioridade);

            if (TarefaCriada != null)
                novaTarefa.Id = TarefaCriada.Id;

            TarefaCriada = novaTarefa;
        }

        private PrioridadeTarefa PegarPrioridadeBaseadaNoIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return PrioridadeTarefa.BAIXA;
                case 1:
                    return PrioridadeTarefa.MEDIA;
                case 2:
                    return PrioridadeTarefa.ALTA;
            }

            return PrioridadeTarefa.BAIXA;
        }

        #region eventos

        private void Event_btn_cancelar_Click(object sender, EventArgs e)
        {
            TarefaCriada = null;
            this.Dispose();
        }

        private void Event_btn_concluir_Click(object sender, EventArgs e)
        {
            MontarTarefa();

            this.Dispose();
        }

        #endregion
    }
}
