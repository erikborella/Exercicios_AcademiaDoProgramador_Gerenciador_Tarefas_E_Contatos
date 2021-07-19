
namespace WindowsFormsApp
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tc_tela = new System.Windows.Forms.TabControl();
            this.tab_tarefa = new System.Windows.Forms.TabPage();
            this.tab_contato = new System.Windows.Forms.TabPage();
            this.tab_compromisso = new System.Windows.Forms.TabPage();
            this.controlContatos1 = new WindowsFormsApp.Contatos.ControlContatos();
            this.controlCompromissos1 = new WindowsFormsApp.Compromissos.ControlCompromissos();
            this.telaTarefas1 = new WindowsFormsApp.Tarefas.ControlTarefas();
            this.tc_tela.SuspendLayout();
            this.tab_tarefa.SuspendLayout();
            this.tab_contato.SuspendLayout();
            this.tab_compromisso.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_tela
            // 
            this.tc_tela.Controls.Add(this.tab_tarefa);
            this.tc_tela.Controls.Add(this.tab_contato);
            this.tc_tela.Controls.Add(this.tab_compromisso);
            this.tc_tela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_tela.Location = new System.Drawing.Point(0, 0);
            this.tc_tela.Name = "tc_tela";
            this.tc_tela.SelectedIndex = 0;
            this.tc_tela.Size = new System.Drawing.Size(609, 429);
            this.tc_tela.TabIndex = 0;
            this.tc_tela.SelectedIndexChanged += new System.EventHandler(this.tc_tela_SelectedIndexChanged);
            // 
            // tab_tarefa
            // 
            this.tab_tarefa.Controls.Add(this.telaTarefas1);
            this.tab_tarefa.Location = new System.Drawing.Point(4, 22);
            this.tab_tarefa.Name = "tab_tarefa";
            this.tab_tarefa.Padding = new System.Windows.Forms.Padding(3);
            this.tab_tarefa.Size = new System.Drawing.Size(601, 403);
            this.tab_tarefa.TabIndex = 0;
            this.tab_tarefa.Text = "Tarefa";
            this.tab_tarefa.UseVisualStyleBackColor = true;
            // 
            // tab_contato
            // 
            this.tab_contato.Controls.Add(this.controlContatos1);
            this.tab_contato.Location = new System.Drawing.Point(4, 22);
            this.tab_contato.Name = "tab_contato";
            this.tab_contato.Padding = new System.Windows.Forms.Padding(3);
            this.tab_contato.Size = new System.Drawing.Size(601, 403);
            this.tab_contato.TabIndex = 1;
            this.tab_contato.Text = "Contato";
            this.tab_contato.UseVisualStyleBackColor = true;
            // 
            // tab_compromisso
            // 
            this.tab_compromisso.Controls.Add(this.controlCompromissos1);
            this.tab_compromisso.Location = new System.Drawing.Point(4, 22);
            this.tab_compromisso.Name = "tab_compromisso";
            this.tab_compromisso.Padding = new System.Windows.Forms.Padding(3);
            this.tab_compromisso.Size = new System.Drawing.Size(601, 403);
            this.tab_compromisso.TabIndex = 2;
            this.tab_compromisso.Text = "Compromisso";
            this.tab_compromisso.UseVisualStyleBackColor = true;
            // 
            // controlContatos1
            // 
            this.controlContatos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlContatos1.Location = new System.Drawing.Point(3, 3);
            this.controlContatos1.Name = "controlContatos1";
            this.controlContatos1.Size = new System.Drawing.Size(595, 397);
            this.controlContatos1.TabIndex = 0;
            this.controlContatos1.Load += new System.EventHandler(this.controlContatos1_Load);
            // 
            // controlCompromissos1
            // 
            this.controlCompromissos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlCompromissos1.Location = new System.Drawing.Point(3, 3);
            this.controlCompromissos1.Name = "controlCompromissos1";
            this.controlCompromissos1.Size = new System.Drawing.Size(595, 397);
            this.controlCompromissos1.TabIndex = 0;
            this.controlCompromissos1.Load += new System.EventHandler(this.controlCompromissos1_Load);
            // 
            // telaTarefas1
            // 
            this.telaTarefas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telaTarefas1.Location = new System.Drawing.Point(3, 3);
            this.telaTarefas1.Name = "telaTarefas1";
            this.telaTarefas1.Size = new System.Drawing.Size(595, 397);
            this.telaTarefas1.TabIndex = 0;
            this.telaTarefas1.Load += new System.EventHandler(this.telaTarefas1_Load);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 429);
            this.Controls.Add(this.tc_tela);
            this.Name = "TelaPrincipal";
            this.Text = "eAgenda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tc_tela.ResumeLayout(false);
            this.tab_tarefa.ResumeLayout(false);
            this.tab_contato.ResumeLayout(false);
            this.tab_compromisso.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_tela;
        private System.Windows.Forms.TabPage tab_tarefa;
        private System.Windows.Forms.TabPage tab_contato;
        private System.Windows.Forms.TabPage tab_compromisso;
        private Contatos.ControlContatos controlContatos1;
        private Compromissos.ControlCompromissos controlCompromissos1;
        private Tarefas.ControlTarefas telaTarefas1;
    }
}

