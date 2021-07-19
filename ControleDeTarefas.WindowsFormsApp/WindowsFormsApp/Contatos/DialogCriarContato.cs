using ControleDeTarefas.Dominios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.Contatos
{
    public partial class DialogCriarContato : Form
    {
        public Contato ContatoCriado { get; private set; }

        public DialogCriarContato()
        {
            InitializeComponent();
        }

        public DialogCriarContato(Contato contato)
        {
            InitializeComponent();

            ContatoCriado = contato;

            text_nome.Text = contato.Nome;
            text_email.Text = contato.Email;
            maskedText_telefone.Text = contato.Telefone;
            text_empresa.Text = contato.Empresa;
            text_cargo.Text = contato.Cargo;
        }

        private void MontarContato()
        {
            string nome = text_nome.Text;
            string email = text_email.Text;
            string telefone = maskedText_telefone.Text;
            string empresa = text_empresa.Text;
            string cargo = text_cargo.Text;

            Contato novoContato = new Contato(nome, email, telefone, empresa, cargo);

            if (ContatoCriado != null)
                novoContato.Id = ContatoCriado.Id;

            ContatoCriado = novoContato;
        }

        #region eventos

        private void Event_text_email_TextChanged(object sender, EventArgs e)
        {
            try
            {
                new MailAddress(text_email.Text);
                toolStripStatusLabel1.Text = "";
                btn_concluir.Enabled = true;

            } catch (Exception)
            {
                toolStripStatusLabel1.Text = "Email não é valido";
                btn_concluir.Enabled = false;
            }
        }

        private void Event_btn_cancelar_Click(object sender, EventArgs e)
        {
            ContatoCriado = null;
            this.Dispose();
        }

        private void Event_btn_concluir_Click(object sender, EventArgs e)
        {
            MontarContato();
            this.Dispose();
        }

        #endregion
    }
}
