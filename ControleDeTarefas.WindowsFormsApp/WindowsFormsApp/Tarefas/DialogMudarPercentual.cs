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
    public partial class DialogMudarPercentual : Form
    {
        public int Percentual { get; private set; }
        public DialogMudarPercentual(int percentualAtual)
        {
            InitializeComponent();

            Percentual = percentualAtual;
            numeric_percentual.Value = percentualAtual;
        }
        #region eventos

        private void Event_btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Event_btn_concluir_Click(object sender, EventArgs e)
        {
            Percentual = Convert.ToInt32(numeric_percentual.Value);
            this.Dispose();
        }

        #endregion
    }
}
