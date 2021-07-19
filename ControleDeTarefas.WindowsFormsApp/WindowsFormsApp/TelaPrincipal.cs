using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void telaTarefas1_Load(object sender, EventArgs e)
        {
            telaTarefas1.PopularTabela();
        }

        private void controlContatos1_Load(object sender, EventArgs e)
        {
            controlContatos1.PopularTabela();
        }

        private void controlCompromissos1_Load(object sender, EventArgs e)
        {
            controlCompromissos1.PopularTabela();
        }

        private void tc_tela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_tela.SelectedTab == tab_compromisso)
                controlCompromissos1.PopularTabela();
        }
    }
}
