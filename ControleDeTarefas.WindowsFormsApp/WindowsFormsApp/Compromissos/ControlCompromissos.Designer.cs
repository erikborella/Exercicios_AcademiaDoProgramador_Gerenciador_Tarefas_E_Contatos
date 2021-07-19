
namespace WindowsFormsApp.Compromissos
{
    partial class ControlCompromissos
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_desde = new System.Windows.Forms.CheckBox();
            this.date_desde = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_ate = new System.Windows.Forms.CheckBox();
            this.date_ate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.radio_passados = new System.Windows.Forms.RadioButton();
            this.radio_futuros = new System.Windows.Forms.RadioButton();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dg_compromissos = new System.Windows.Forms.DataGridView();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_assunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_horaInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_horaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_contatoNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_contatoTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_criar = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_compromissos)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(659, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(178, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Por periodo";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(472, 60);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.cb_desde, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.date_desde, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(466, 24);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // cb_desde
            // 
            this.cb_desde.AutoSize = true;
            this.cb_desde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_desde.Location = new System.Drawing.Point(3, 3);
            this.cb_desde.Name = "cb_desde";
            this.cb_desde.Size = new System.Drawing.Size(64, 18);
            this.cb_desde.TabIndex = 0;
            this.cb_desde.Text = "Desde:";
            this.cb_desde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_desde.UseVisualStyleBackColor = true;
            this.cb_desde.CheckedChanged += new System.EventHandler(this.Event_cb_desde_CheckedChanged);
            // 
            // date_desde
            // 
            this.date_desde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_desde.Enabled = false;
            this.date_desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_desde.Location = new System.Drawing.Point(73, 3);
            this.date_desde.Name = "date_desde";
            this.date_desde.Size = new System.Drawing.Size(390, 20);
            this.date_desde.TabIndex = 1;
            this.date_desde.ValueChanged += new System.EventHandler(this.Event_date_desde_ValueChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.cb_ate, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.date_ate, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(466, 24);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // cb_ate
            // 
            this.cb_ate.AutoSize = true;
            this.cb_ate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_ate.Location = new System.Drawing.Point(3, 3);
            this.cb_ate.Name = "cb_ate";
            this.cb_ate.Size = new System.Drawing.Size(64, 18);
            this.cb_ate.TabIndex = 0;
            this.cb_ate.Text = "Até:";
            this.cb_ate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_ate.UseVisualStyleBackColor = true;
            this.cb_ate.CheckedChanged += new System.EventHandler(this.Event_cb_ate_CheckedChanged);
            // 
            // date_ate
            // 
            this.date_ate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_ate.Enabled = false;
            this.date_ate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_ate.Location = new System.Drawing.Point(73, 3);
            this.date_ate.Name = "date_ate";
            this.date_ate.Size = new System.Drawing.Size(390, 20);
            this.date_ate.TabIndex = 1;
            this.date_ate.ValueChanged += new System.EventHandler(this.Event_date_ate_ValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_limpar, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(169, 79);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.radio_passados, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.radio_futuros, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(163, 33);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // radio_passados
            // 
            this.radio_passados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radio_passados.Location = new System.Drawing.Point(3, 3);
            this.radio_passados.Name = "radio_passados";
            this.radio_passados.Size = new System.Drawing.Size(75, 27);
            this.radio_passados.TabIndex = 0;
            this.radio_passados.TabStop = true;
            this.radio_passados.Text = "Passados";
            this.radio_passados.UseVisualStyleBackColor = true;
            this.radio_passados.CheckedChanged += new System.EventHandler(this.Event_radio_passados_CheckedChanged);
            // 
            // radio_futuros
            // 
            this.radio_futuros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radio_futuros.Location = new System.Drawing.Point(84, 3);
            this.radio_futuros.Name = "radio_futuros";
            this.radio_futuros.Size = new System.Drawing.Size(76, 27);
            this.radio_futuros.TabIndex = 1;
            this.radio_futuros.TabStop = true;
            this.radio_futuros.Text = "Futuros";
            this.radio_futuros.UseVisualStyleBackColor = true;
            this.radio_futuros.CheckedChanged += new System.EventHandler(this.Event_radio_futuros_CheckedChanged);
            // 
            // btn_limpar
            // 
            this.btn_limpar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_limpar.Location = new System.Drawing.Point(7, 46);
            this.btn_limpar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(155, 26);
            this.btn_limpar.TabIndex = 2;
            this.btn_limpar.Text = "Limpar";
            this.btn_limpar.UseVisualStyleBackColor = true;
            this.btn_limpar.Click += new System.EventHandler(this.Event_btn_limpar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dg_compromissos);
            this.groupBox3.Location = new System.Drawing.Point(6, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(659, 178);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compromissos";
            // 
            // dg_compromissos
            // 
            this.dg_compromissos.AllowUserToAddRows = false;
            this.dg_compromissos.AllowUserToDeleteRows = false;
            this.dg_compromissos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_compromissos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_compromissos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_id,
            this.cl_assunto,
            this.cl_Local,
            this.cl_data,
            this.cl_horaInicial,
            this.cl_horaFinal,
            this.cl_contatoNome,
            this.cl_contatoTelefone});
            this.dg_compromissos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dg_compromissos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_compromissos.Location = new System.Drawing.Point(3, 16);
            this.dg_compromissos.MultiSelect = false;
            this.dg_compromissos.Name = "dg_compromissos";
            this.dg_compromissos.ReadOnly = true;
            this.dg_compromissos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_compromissos.Size = new System.Drawing.Size(653, 159);
            this.dg_compromissos.TabIndex = 1;
            // 
            // cl_id
            // 
            this.cl_id.HeaderText = "Id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ReadOnly = true;
            // 
            // cl_assunto
            // 
            this.cl_assunto.HeaderText = "Assunto";
            this.cl_assunto.Name = "cl_assunto";
            this.cl_assunto.ReadOnly = true;
            // 
            // cl_Local
            // 
            this.cl_Local.HeaderText = "Local";
            this.cl_Local.Name = "cl_Local";
            this.cl_Local.ReadOnly = true;
            // 
            // cl_data
            // 
            this.cl_data.HeaderText = "Data";
            this.cl_data.Name = "cl_data";
            this.cl_data.ReadOnly = true;
            // 
            // cl_horaInicial
            // 
            this.cl_horaInicial.HeaderText = "Hora de Inicio";
            this.cl_horaInicial.Name = "cl_horaInicial";
            this.cl_horaInicial.ReadOnly = true;
            // 
            // cl_horaFinal
            // 
            this.cl_horaFinal.HeaderText = "Hora de termino";
            this.cl_horaFinal.Name = "cl_horaFinal";
            this.cl_horaFinal.ReadOnly = true;
            // 
            // cl_contatoNome
            // 
            this.cl_contatoNome.HeaderText = "Contato";
            this.cl_contatoNome.Name = "cl_contatoNome";
            this.cl_contatoNome.ReadOnly = true;
            // 
            // cl_contatoTelefone
            // 
            this.cl_contatoTelefone.HeaderText = "Telefone";
            this.cl_contatoTelefone.Name = "cl_contatoTelefone";
            this.cl_contatoTelefone.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tableLayoutPanel7);
            this.groupBox4.Location = new System.Drawing.Point(9, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(653, 63);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Funções";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.btn_criar, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btn_editar, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.btn_excluir, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(647, 44);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // btn_criar
            // 
            this.btn_criar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_criar.Location = new System.Drawing.Point(7, 7);
            this.btn_criar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_criar.Name = "btn_criar";
            this.btn_criar.Size = new System.Drawing.Size(201, 30);
            this.btn_criar.TabIndex = 0;
            this.btn_criar.Text = "Criar";
            this.btn_criar.UseVisualStyleBackColor = true;
            this.btn_criar.Click += new System.EventHandler(this.Event_btn_criar_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_editar.Location = new System.Drawing.Point(222, 7);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(201, 30);
            this.btn_editar.TabIndex = 1;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.Event_btn_editar_Click);
            // 
            // btn_excluir
            // 
            this.btn_excluir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_excluir.Location = new System.Drawing.Point(437, 7);
            this.btn_excluir.Margin = new System.Windows.Forms.Padding(7);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(203, 30);
            this.btn_excluir.TabIndex = 2;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.Event_btn_excluir_Click);
            // 
            // ControlCompromissos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ControlCompromissos";
            this.Size = new System.Drawing.Size(671, 369);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_compromissos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox cb_desde;
        private System.Windows.Forms.DateTimePicker date_desde;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox cb_ate;
        private System.Windows.Forms.DateTimePicker date_ate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton radio_passados;
        private System.Windows.Forms.RadioButton radio_futuros;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dg_compromissos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_assunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_horaInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_horaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_contatoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_contatoTelefone;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button btn_criar;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_excluir;
    }
}
