using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ControleDeTarefas.Dominios;

namespace WindowsFormsApp.Compromissos
{
    public partial class DialogCompromissosCriar : Form
    {
        public Compromisso CompromissoCriado { get; private set; }

        private Compromisso[] compromissosCache;

        public DialogCompromissosCriar(Contato[] contatos, Compromisso[] compromissosCache)
        {
            InitializeComponent();

            this.compromissosCache = compromissosCache;

            PopularTabelaContatos(contatos);
        }

        public DialogCompromissosCriar(Contato[] contatos, 
            Compromisso[] compromissosCache, Compromisso compromissoParaEditar)
        {
            InitializeComponent();

            this.compromissosCache = compromissosCache;

            PopularTabelaContatos(contatos);

            CompromissoCriado = compromissoParaEditar;

            text_assunto.Text = compromissoParaEditar.Assunto;
            text_local.Text = compromissoParaEditar.Local;
            date_data.Value = compromissoParaEditar.Data;
            date_horaInicial.Value = 
                ConverterTimeSpanParaDateTime(compromissoParaEditar.Data, compromissoParaEditar.HoraInicial);
            date_horaFinal.Value =
                ConverterTimeSpanParaDateTime(compromissoParaEditar.Data, compromissoParaEditar.HoraFinal);

            if (compromissoParaEditar.Contato != null)
            {
                cb_incluirContato.Checked = true;
                SelecionarLinhaContato(compromissoParaEditar.Contato.Id);
            }
        }

        private DateTime ConverterTimeSpanParaDateTime(DateTime data, TimeSpan hora)
        {
            DateTime novaData = data.Date;
            novaData += hora;

            return novaData;
        }

        private void PopularTabelaContatos(Contato[] contatos)
        {
            dg_contatos.Rows.Clear();

            foreach (Contato contato in contatos)
            {
                dg_contatos.Rows.Add(
                    contato.Id,
                    contato.Nome,
                    contato.Email,
                    contato.Telefone,
                    contato.Empresa,
                    contato.Cargo
                );
            }
        }

        private void SelecionarLinhaContato(int id)
        {
            for (int i = 0; i < dg_contatos.Rows.Count; i++)
            {
                int idLinha = (int)dg_contatos.Rows[i].Cells[0].Value;

                if (idLinha == id)
                {
                    dg_contatos.ClearSelection();
                    dg_contatos.Rows[i].Selected = true;
                    return;
                }

            }
        }

        private int PegarIdContatoSelecionado()
        {
            if (dg_contatos.SelectedRows.Count == 0)
                return -1;
            else
            {
                DataGridViewRow linhaSelecionada = dg_contatos.SelectedRows[0];
                int id = (int)linhaSelecionada.Cells[0].Value;

                return id;
            }
        }

        #region eventos

        private void Event_btn_cancelar_Click(object sender, EventArgs e)
        {
            CompromissoCriado = null;
            this.Dispose();
        }

        private void Event_btn_concluir_Click(object sender, EventArgs e)
        {
            string assunto = text_assunto.Text;
            string local = text_local.Text;
            DateTime data = date_data.Value;
            TimeSpan horaInicial = date_horaInicial.Value.TimeOfDay;
            TimeSpan horaFinal = date_horaFinal.Value.TimeOfDay;

            Contato contato = null;

            if (cb_incluirContato.Checked)
            {
                int contatoId = PegarIdContatoSelecionado();

                if (contatoId == -1)
                {
                    MessageBox.Show("Selecione um contato!");
                    return;
                }

                contato = new Contato(contatoId);
            }

            Compromisso compromisso = 
                new Compromisso(assunto, local, data, horaInicial, horaFinal, contato);

            if (CompromissoCriado != null)
                compromisso.Id = CompromissoCriado.Id;

            CompromissoCriado = compromisso;

            this.Dispose();
        }

        private void Event_cb_incluirContato_CheckedChanged(object sender, EventArgs e)
        {
            dg_contatos.Enabled = cb_incluirContato.Checked;
        }

        private void Event_verificarConflitos(object sender, EventArgs e)
        {
            DateTime data = date_data.Value.Date;
            TimeSpan horaInicial = date_horaInicial.Value.TimeOfDay;
            TimeSpan horaFinal = date_horaFinal.Value.TimeOfDay;

            Compromisso compromissoConflitante = compromissosCache
                .Where(c =>
                {
                    if (c.Data.Date != data)
                        return false;

                    if (CompromissoCriado != null && CompromissoCriado.Equals(c))
                        return false;

                    if (horaInicial >= c.HoraInicial && horaInicial <= c.HoraFinal)
                        return true;

                    if (horaFinal >= c.HoraInicial && horaFinal <= c.HoraFinal)
                        return true;

                    if (horaInicial <= c.HoraInicial && horaFinal >= c.HoraFinal)
                        return true;

                    return false;
                })
                .FirstOrDefault();

            if (compromissoConflitante == null)
            {
                toolStripStatusLabel.Text = "";
                btn_concluir.Enabled = true;
            } else
            {
                toolStripStatusLabel.Text =
                    $"As datas e horas entram em conflito com o compromisso: {compromissoConflitante.Assunto}";
                btn_concluir.Enabled = false;
            }
        }

        private void Event_date_horaInicial_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTemp = date_horaInicial.Value;
            TimeSpan horaInicial = dateTemp.TimeOfDay;

            date_horaFinal.MinDate = ConverterTimeSpanParaDateTime(dateTemp, horaInicial);

            if (horaInicial > date_horaFinal.Value.TimeOfDay)
                date_horaFinal.Value = date_horaFinal.MinDate;

            Event_verificarConflitos(sender, e);
        }

        private void Event_date_data_ValueChanged(object sender, EventArgs e)
        {
            DateTime data = date_data.Value;

            if (data.DayOfWeek == DayOfWeek.Saturday)
            {
                toolStripStatusLabel.Text = "Você não pode definir uma tarefa no sabado!";
                btn_concluir.Enabled = false;
                return;
            }

            if (data.DayOfWeek == DayOfWeek.Sunday)
            {
                toolStripStatusLabel.Text = "Você não pode definir uma tarefa no domingo!";
                btn_concluir.Enabled = false;
                return;
            }

            toolStripStatusLabel.Text = "";
            btn_concluir.Enabled = true;

            Event_verificarConflitos(sender, e);
        }

        #endregion
    }
}
