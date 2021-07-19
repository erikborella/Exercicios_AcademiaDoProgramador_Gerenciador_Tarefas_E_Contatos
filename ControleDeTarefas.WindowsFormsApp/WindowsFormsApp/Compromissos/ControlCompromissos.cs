using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Dominios;

namespace WindowsFormsApp.Compromissos
{
    public partial class ControlCompromissos : UserControl
    {
        private Compromisso[] compromissosCache;
        public ControlCompromissos()
        {
            InitializeComponent();
        }

        public void PopularTabela()
        {
            ControladorCompromisso controladorCompromisso = CriarControlador();

            compromissosCache = controladorCompromisso.BuscarRegistros();

            AtualizarTabela(compromissosCache);
        }

        private void AtualizarTabela(Compromisso[] compromissos)
        {
            dg_compromissos.Rows.Clear();

            Compromisso[] compromissosFiltrados = FiltrarCompromissos(compromissos);

            foreach (Compromisso compromisso in compromissosFiltrados)
            {
                dg_compromissos.Rows.Add(
                    compromisso.Id,
                    compromisso.Assunto,
                    compromisso.Local,
                    compromisso.Data,
                    compromisso.HoraInicial,
                    compromisso.HoraFinal,
                    (compromisso.Contato != null) ? 
                        compromisso.Contato.Nome:"(Sem contato)",
                    (compromisso.Contato != null) ? 
                        compromisso.Contato.Telefone:"(Sem contato)"
                );
            }
        }

        #region filtros

        private Compromisso[] FiltrarCompromissos(Compromisso[] compromissos)
        {
            Compromisso[] compromissosFiltrados = compromissos;

            if (radio_futuros.Checked)
                compromissosFiltrados = FiltrarFuturos(compromissosFiltrados);
            else if (radio_passados.Checked)
                compromissosFiltrados = FiltrarPassados(compromissosFiltrados);

            if (cb_desde.Checked)
                compromissosFiltrados = FiltrarDataDesde(compromissosFiltrados);

            if (cb_ate.Checked)
                compromissosFiltrados = FiltrarDataAte(compromissosFiltrados);

            return compromissosFiltrados;
        }

        private Compromisso[] FiltrarDataAte(Compromisso[] compromissosFiltrados)
        {
            DateTime dataAte = date_ate.Value;

            return compromissosFiltrados
                .Where(c => c.Data <= dataAte)
                .ToArray();
        }

        private Compromisso[] FiltrarDataDesde(Compromisso[] compromissosFiltrados)
        {
            DateTime dataDesde = date_desde.Value;

            return compromissosFiltrados
                .Where(c => dataDesde <= c.Data)
                .ToArray();
        }

        private Compromisso[] FiltrarFuturos(Compromisso[] compromissosFiltrados)
        {
            DateTime dataAgora = DateTime.Now;

            return compromissosFiltrados
                .Where(c => c.Data > dataAgora)
                .ToArray();
        }

        private Compromisso[] FiltrarPassados(Compromisso[] compromissosFiltrados)
        {
            DateTime dataAgora = DateTime.Now;

            return compromissosFiltrados
                .Where(c => c.Data <= dataAgora)
                .ToArray();
        }

        #endregion

        private ControladorCompromisso CriarControlador()
        {
            ControladorContato controladorContato = new ControladorContato();
            return new ControladorCompromisso(controladorContato);
        }

        private Contato[] PegarContatos()
        {
            ControladorContato controladorContato = new ControladorContato();

            return controladorContato.BuscarRegistros()
                .OrderBy(c => c.Cargo.ToLower())
                .ToArray(); 
        }


        private static void MostrarErroSelecioneCompromisso()
        {
            MessageBox.Show("Selecione um compromisso!");
        }

        private int PegarIdSelecionado()
        {
            if (dg_compromissos.SelectedRows.Count == 0)
                return -1;

            DataGridViewRow linhaSelecionada = dg_compromissos.SelectedRows[0];
            int id = (int)linhaSelecionada.Cells[0].Value;

            return id;
        }

        private Compromisso PegarCompromissoSelecionado(
            ControladorCompromisso controladorCompromisso)
        {
            int id = PegarIdSelecionado();

            if (id == -1)
                return null;

            return controladorCompromisso.BuscarRegistroPorId(id);
        }

        #region eventos

        private void Event_cb_desde_CheckedChanged(object sender, EventArgs e)
        {
            date_desde.Enabled = cb_desde.Checked;

            AtualizarTabela(compromissosCache);
        }

        private void Event_cb_ate_CheckedChanged(object sender, EventArgs e)
        {
            date_ate.Enabled = cb_ate.Checked;

            AtualizarTabela(compromissosCache);
        }

        private void Event_btn_limpar_Click(object sender, EventArgs e)
        {
            radio_passados.Checked = false;
            radio_futuros.Checked = false;

            AtualizarTabela(compromissosCache);
        }

        private void Event_radio_passados_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarTabela(compromissosCache);
        }

        private void Event_radio_futuros_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarTabela(compromissosCache);
        }

        private void Event_date_desde_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTabela(compromissosCache);
        }

        private void Event_date_ate_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTabela(compromissosCache);
        }

        private void Event_btn_criar_Click(object sender, EventArgs e)
        {
            DialogCompromissosCriar dialogCompromissosCriar =
                new DialogCompromissosCriar(PegarContatos(), compromissosCache);
            dialogCompromissosCriar.ShowDialog();

            Compromisso compromisso = dialogCompromissosCriar.CompromissoCriado;

            if (compromisso == null)
                return;

            ControladorCompromisso controladorCompromisso = CriarControlador();

            controladorCompromisso.Inserir(compromisso);

            this.PopularTabela();
        }

        private void Event_btn_editar_Click(object sender, EventArgs e)
        {
            ControladorCompromisso controladorCompromisso = CriarControlador();

            Compromisso compromisso = PegarCompromissoSelecionado(controladorCompromisso);

            if (compromisso == null)
            {
                MostrarErroSelecioneCompromisso();
                return;
            }

            DialogCompromissosCriar dialogCompromissosCriar =
                new DialogCompromissosCriar(PegarContatos(), compromissosCache, compromisso);
            dialogCompromissosCriar.ShowDialog();

            Compromisso compromissoCriado = dialogCompromissosCriar.CompromissoCriado;

            if (compromissoCriado == null)
                return;

            controladorCompromisso.Editar(compromissoCriado);

            this.PopularTabela();
        }

        private void Event_btn_excluir_Click(object sender, EventArgs e)
        {
            ControladorCompromisso controladorCompromisso = CriarControlador();

            int idSelecionado = PegarIdSelecionado();

            if (idSelecionado == -1)
            {
                MostrarErroSelecioneCompromisso();
                return;
            }

            DialogResult confimacaoExcluir =
                MessageBox.Show("Tem certeza que deseja excluir esse contato:",
                "Confirme a opção",
                MessageBoxButtons.YesNo);

            if (confimacaoExcluir == DialogResult.No)
                return;

            controladorCompromisso.Excluir(idSelecionado);

            this.PopularTabela();
        }

        #endregion

    }
}
