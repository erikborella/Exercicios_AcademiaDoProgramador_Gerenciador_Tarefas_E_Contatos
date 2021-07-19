using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp;

using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Dominios;

namespace WindowsFormsApp.Tarefas
{
    public partial class ControlTarefas : UserControl
    {
        public ControlTarefas()
        {
            InitializeComponent();
        }

        public void PopularTabela()
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();

            Tarefa[] tarefas = controladorTarefa.BuscarRegistros();

            Tarefa[] tarefasConcluidas =
                tarefas.Where(t => t.PercentualConcluido == 100)
                .OrderByDescending(t => t.Prioridade)
                .ThenBy(t => t.PercentualConcluido)
                .ToArray();

            Tarefa[] tarefasPendentes =
                tarefas.Where(t => t.PercentualConcluido != 100)
                .OrderByDescending(t => t.Prioridade)
                .ThenByDescending(t => t.PercentualConcluido)
                .ToArray();

            PreencherTabelaComTarefas(dg_tarefasConcluidas, tarefasConcluidas);

            PreencherTabelaComTarefas(dg_tarefasPendentes, tarefasPendentes);
        }

        private void PreencherTabelaComTarefas(DataGridView dataGrid, Tarefa[] tarefas)
        {
            dataGrid.Rows.Clear();

            foreach (Tarefa tarefa in tarefas)
            {
                dataGrid.Rows.Add(
                    tarefa.Id,
                    tarefa.Titulo,
                    tarefa.DataCriacao.ToString(),
                    tarefa.DataConclusao.ToString(),
                    tarefa.PercentualConcluido,
                    tarefa.Prioridade.ToString()
                );
            }
        }

        private DataGridView PegarTabelaEmContexto()
        {
            int tabSelecionada = tabControl_tarefas.SelectedIndex;

            if (tabSelecionada == 0)
                return dg_tarefasPendentes;
            else
                return dg_tarefasConcluidas;
        }

        private Tarefa PegarTarefaSelecionada(ControladorTarefa controladorTarefa)
        {
            int idSelecionado = PegarIdSelecionado();

            if (idSelecionado == -1)
                return null;

            return controladorTarefa.BuscarRegistroPorId(idSelecionado);
        }

        private int PegarIdSelecionado()
        {
            DataGridView tabela = PegarTabelaEmContexto();

            if (tabela.SelectedRows.Count == 0)
                return -1;

            DataGridViewRow linhaSelecionada = tabela.SelectedRows[0];
            int idSelecionado = (int)linhaSelecionada.Cells[0].Value;
            return idSelecionado;
        }

        private static void MostrarErroTarefaNaoSelecionada()
        {
            MessageBox.Show("Selecione alguma tarefa!");
        }

        #region eventos

        private void Event_btn_Criar_Click(object sender, EventArgs e)
        {
            TelaCriarTarefa telaCriarTarefa = new TelaCriarTarefa();
            telaCriarTarefa.ShowDialog();

            Tarefa tarefa = telaCriarTarefa.TarefaCriada;

            if (tarefa == null)
                return;

            ControladorTarefa controladorTarefa = new ControladorTarefa();

            controladorTarefa.Inserir(tarefa);

            this.PopularTabela();
        }

        private void Event_btn_Editar_Click(object sender, EventArgs e)
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();

            Tarefa tarefa = PegarTarefaSelecionada(controladorTarefa);

            if (tarefa == null)
            {
                MostrarErroTarefaNaoSelecionada();
                return;
            }

            TelaCriarTarefa telaCriarTarefa = new TelaCriarTarefa(tarefa);
            telaCriarTarefa.ShowDialog();

            Tarefa novaTarefa = telaCriarTarefa.TarefaCriada;

            if (novaTarefa == null)
                return;

            controladorTarefa.Editar(novaTarefa);

            this.PopularTabela();
        }

        private void Event_btn_Excluir_Click(object sender, EventArgs e)
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();

            int idSelecionado = PegarIdSelecionado();

            if (idSelecionado == -1)
            {
                MostrarErroTarefaNaoSelecionada();
                return;
            }

            DialogResult confimacaoExcluir = MessageBox.Show("Tem certeza que deseja excluir?",
                "Confirme a opção",
                MessageBoxButtons.YesNo);

            if (confimacaoExcluir == DialogResult.No)
                return;

            controladorTarefa.Excluir(idSelecionado);

            this.PopularTabela();
        }

        private void Event_btn_MudarPercentual_Click(object sender, EventArgs e)
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();

            Tarefa tarefa = PegarTarefaSelecionada(controladorTarefa);

            if (tarefa == null)
            {
                MostrarErroTarefaNaoSelecionada();
                return;
            }

            DialogMudarPercentual dialogMudarPercentual = new DialogMudarPercentual(
                tarefa.PercentualConcluido);
            dialogMudarPercentual.ShowDialog();

            int novoPercentual = dialogMudarPercentual.Percentual;

            if (novoPercentual == tarefa.PercentualConcluido)
                return;

            controladorTarefa.AtualizarPercentualConcluido(
                tarefa.Id, novoPercentual);

            this.PopularTabela();
        }

        private void Event_tabControl_tarefas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_tarefas.SelectedIndex == 1)
                btn_mudarPercentual.Enabled = false;
            else
                btn_mudarPercentual.Enabled = true;
        }

        #endregion
    }
}
