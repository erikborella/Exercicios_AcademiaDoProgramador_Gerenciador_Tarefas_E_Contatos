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

namespace WindowsFormsApp.Contatos
{
    public partial class ControlContatos : UserControl
    {
        public ControlContatos()
        {
            InitializeComponent();
        }

        public void PopularTabela()
        {
            dg_contatos.Rows.Clear();

            ControladorContato controladorContato = new ControladorContato();

            Contato[] contatos = controladorContato.BuscarRegistros()
                .OrderBy(c => c.Cargo.ToLower())
                .ToArray();

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

        private int PegarIdSelecionado()
        {
            if (dg_contatos.SelectedRows.Count == 0)
                return -1;

            DataGridViewRow linhaSelecionada = dg_contatos.SelectedRows[0];
            int idSelecionado = (int)linhaSelecionada.Cells[0].Value;

            return idSelecionado;
        }

        private Contato PegarContatoSelecionado(ControladorContato controladorContato)
        {
            int idSelecionado = PegarIdSelecionado();

            if (idSelecionado == -1)
                return null;

            return controladorContato.BuscarRegistroPorId(idSelecionado);
        }

        private static void MostrarErroContatoNaoSelecionado()
        {
            MessageBox.Show("Selecione algum contato!");
        }

        #region eventos

        private void Event_btn_criar_Click(object sender, EventArgs e)
        {
            DialogCriarContato dialogCriarContato = new DialogCriarContato();
            dialogCriarContato.ShowDialog();

            Contato contato = dialogCriarContato.ContatoCriado;

            if (contato == null)
                return;

            ControladorContato controladorContato = new ControladorContato();
            controladorContato.Inserir(contato);

            this.PopularTabela();
        }

        private void Event_btn_editar_Click(object sender, EventArgs e)
        {
            ControladorContato controladorContato = new ControladorContato();

            Contato contato = PegarContatoSelecionado(controladorContato);

            if (contato == null)
            {
                MostrarErroContatoNaoSelecionado();
                return;
            }

            DialogCriarContato dialogCriarContato = new DialogCriarContato(contato);
            dialogCriarContato.ShowDialog();

            Contato novoContato = dialogCriarContato.ContatoCriado;

            if (novoContato == null)
                return;

            controladorContato.Editar(novoContato);

            this.PopularTabela();
        }

        private void Evenet_btn_excluir_Click(object sender, EventArgs e)
        {
            ControladorContato controladorContato = new ControladorContato();

            int idSelecionado = PegarIdSelecionado();

            if (idSelecionado == -1)
            {
                MostrarErroContatoNaoSelecionado();
                return;
            }

            DialogResult confimacaoExcluir =
                MessageBox.Show("Tem certeza que deseja excluir esse contato:",
                "Confirme a opção",
                MessageBoxButtons.YesNo);

            if (confimacaoExcluir == DialogResult.No)
                return;

            controladorContato.Excluir(idSelecionado);

            this.PopularTabela();
        }

        #endregion
    }
}
