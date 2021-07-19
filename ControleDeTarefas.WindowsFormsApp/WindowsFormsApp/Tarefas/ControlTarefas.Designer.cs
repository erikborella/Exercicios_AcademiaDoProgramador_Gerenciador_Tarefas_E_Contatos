
namespace WindowsFormsApp.Tarefas
{
    partial class ControlTarefas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl_tarefas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dg_tarefasPendentes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dg_tarefasConcluidas = new System.Windows.Forms.DataGridView();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dataConclusao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_percentualConcluido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_Prioridade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_criar = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_mudarPercentual = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl_tarefas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_tarefasPendentes)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_tarefasConcluidas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl_tarefas);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tarefas";
            // 
            // tabControl_tarefas
            // 
            this.tabControl_tarefas.Controls.Add(this.tabPage1);
            this.tabControl_tarefas.Controls.Add(this.tabPage2);
            this.tabControl_tarefas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_tarefas.Location = new System.Drawing.Point(3, 16);
            this.tabControl_tarefas.Name = "tabControl_tarefas";
            this.tabControl_tarefas.SelectedIndex = 0;
            this.tabControl_tarefas.Size = new System.Drawing.Size(526, 214);
            this.tabControl_tarefas.TabIndex = 0;
            this.tabControl_tarefas.SelectedIndexChanged += new System.EventHandler(this.Event_tabControl_tarefas_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg_tarefasPendentes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(518, 188);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pendentes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dg_tarefasPendentes
            // 
            this.dg_tarefasPendentes.AllowUserToAddRows = false;
            this.dg_tarefasPendentes.AllowUserToDeleteRows = false;
            this.dg_tarefasPendentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_tarefasPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_tarefasPendentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dg_tarefasPendentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dg_tarefasPendentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_tarefasPendentes.Location = new System.Drawing.Point(3, 3);
            this.dg_tarefasPendentes.MultiSelect = false;
            this.dg_tarefasPendentes.Name = "dg_tarefasPendentes";
            this.dg_tarefasPendentes.ReadOnly = true;
            this.dg_tarefasPendentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_tarefasPendentes.Size = new System.Drawing.Size(512, 182);
            this.dg_tarefasPendentes.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Titulo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Data Criação";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Data Conclusão";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Percentual Concluido";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Prioridade";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dg_tarefasConcluidas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(522, 178);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Concluidas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dg_tarefasConcluidas
            // 
            this.dg_tarefasConcluidas.AllowUserToAddRows = false;
            this.dg_tarefasConcluidas.AllowUserToDeleteRows = false;
            this.dg_tarefasConcluidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_tarefasConcluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_tarefasConcluidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_id,
            this.cl_titulo,
            this.cl_dataCriacao,
            this.cl_dataConclusao,
            this.cl_percentualConcluido,
            this.cl_Prioridade});
            this.dg_tarefasConcluidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dg_tarefasConcluidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_tarefasConcluidas.Location = new System.Drawing.Point(3, 3);
            this.dg_tarefasConcluidas.MultiSelect = false;
            this.dg_tarefasConcluidas.Name = "dg_tarefasConcluidas";
            this.dg_tarefasConcluidas.ReadOnly = true;
            this.dg_tarefasConcluidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_tarefasConcluidas.Size = new System.Drawing.Size(516, 172);
            this.dg_tarefasConcluidas.TabIndex = 1;
            // 
            // cl_id
            // 
            this.cl_id.HeaderText = "Id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ReadOnly = true;
            // 
            // cl_titulo
            // 
            this.cl_titulo.HeaderText = "Titulo";
            this.cl_titulo.Name = "cl_titulo";
            this.cl_titulo.ReadOnly = true;
            // 
            // cl_dataCriacao
            // 
            this.cl_dataCriacao.HeaderText = "Data Criação";
            this.cl_dataCriacao.Name = "cl_dataCriacao";
            this.cl_dataCriacao.ReadOnly = true;
            // 
            // cl_dataConclusao
            // 
            this.cl_dataConclusao.HeaderText = "Data Conclusão";
            this.cl_dataConclusao.Name = "cl_dataConclusao";
            this.cl_dataConclusao.ReadOnly = true;
            // 
            // cl_percentualConcluido
            // 
            this.cl_percentualConcluido.HeaderText = "Percentual Concluido";
            this.cl_percentualConcluido.Name = "cl_percentualConcluido";
            this.cl_percentualConcluido.ReadOnly = true;
            // 
            // cl_Prioridade
            // 
            this.cl_Prioridade.HeaderText = "Prioridade";
            this.cl_Prioridade.Name = "cl_Prioridade";
            this.cl_Prioridade.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(6, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funções";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btn_criar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_editar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_excluir, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_mudarPercentual, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_criar
            // 
            this.btn_criar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_criar.Location = new System.Drawing.Point(7, 7);
            this.btn_criar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_criar.Name = "btn_criar";
            this.btn_criar.Size = new System.Drawing.Size(116, 30);
            this.btn_criar.TabIndex = 0;
            this.btn_criar.Text = "Criar";
            this.btn_criar.UseVisualStyleBackColor = true;
            this.btn_criar.Click += new System.EventHandler(this.Event_btn_Criar_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_editar.Location = new System.Drawing.Point(137, 7);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(116, 30);
            this.btn_editar.TabIndex = 1;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.Event_btn_Editar_Click);
            // 
            // btn_excluir
            // 
            this.btn_excluir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_excluir.Location = new System.Drawing.Point(267, 7);
            this.btn_excluir.Margin = new System.Windows.Forms.Padding(7);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(116, 30);
            this.btn_excluir.TabIndex = 2;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.Event_btn_Excluir_Click);
            // 
            // btn_mudarPercentual
            // 
            this.btn_mudarPercentual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_mudarPercentual.Location = new System.Drawing.Point(397, 7);
            this.btn_mudarPercentual.Margin = new System.Windows.Forms.Padding(7);
            this.btn_mudarPercentual.Name = "btn_mudarPercentual";
            this.btn_mudarPercentual.Size = new System.Drawing.Size(116, 30);
            this.btn_mudarPercentual.TabIndex = 3;
            this.btn_mudarPercentual.Text = "Mudar Percentual";
            this.btn_mudarPercentual.UseVisualStyleBackColor = true;
            this.btn_mudarPercentual.Click += new System.EventHandler(this.Event_btn_MudarPercentual_Click);
            // 
            // ControlTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ControlTarefas";
            this.Size = new System.Drawing.Size(535, 309);
            this.groupBox1.ResumeLayout(false);
            this.tabControl_tarefas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_tarefasPendentes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_tarefasConcluidas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_criar;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.TabControl tabControl_tarefas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dg_tarefasPendentes;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dg_tarefasConcluidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_dataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_dataConclusao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_percentualConcluido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_Prioridade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btn_mudarPercentual;
    }
}
