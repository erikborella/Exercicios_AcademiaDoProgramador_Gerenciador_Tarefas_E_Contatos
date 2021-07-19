
namespace WindowsFormsApp.Compromissos
{
    partial class DialogCompromissosCriar
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_assunto = new System.Windows.Forms.TextBox();
            this.text_local = new System.Windows.Forms.TextBox();
            this.date_data = new System.Windows.Forms.DateTimePicker();
            this.date_horaInicial = new System.Windows.Forms.DateTimePicker();
            this.date_horaFinal = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_contatos = new System.Windows.Forms.DataGridView();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_incluirContato = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_concluir = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_contatos)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compromisso";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.text_assunto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.text_local, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.date_data, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.date_horaInicial, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.date_horaFinal, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 158);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Assunto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Local:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hora de inicio:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 26);
            this.label6.TabIndex = 4;
            this.label6.Text = "Hora de termino:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // text_assunto
            // 
            this.text_assunto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_assunto.Location = new System.Drawing.Point(58, 3);
            this.text_assunto.Name = "text_assunto";
            this.text_assunto.Size = new System.Drawing.Size(271, 20);
            this.text_assunto.TabIndex = 5;
            // 
            // text_local
            // 
            this.text_local.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_local.Location = new System.Drawing.Point(58, 34);
            this.text_local.Name = "text_local";
            this.text_local.Size = new System.Drawing.Size(271, 20);
            this.text_local.TabIndex = 6;
            // 
            // date_data
            // 
            this.date_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_data.Location = new System.Drawing.Point(58, 65);
            this.date_data.Name = "date_data";
            this.date_data.Size = new System.Drawing.Size(271, 20);
            this.date_data.TabIndex = 7;
            this.date_data.ValueChanged += new System.EventHandler(this.Event_date_data_ValueChanged);
            // 
            // date_horaInicial
            // 
            this.date_horaInicial.CustomFormat = "HH:mm";
            this.date_horaInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_horaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_horaInicial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.date_horaInicial.Location = new System.Drawing.Point(58, 96);
            this.date_horaInicial.Name = "date_horaInicial";
            this.date_horaInicial.ShowUpDown = true;
            this.date_horaInicial.Size = new System.Drawing.Size(271, 20);
            this.date_horaInicial.TabIndex = 8;
            this.date_horaInicial.ValueChanged += new System.EventHandler(this.Event_date_horaInicial_ValueChanged);
            // 
            // date_horaFinal
            // 
            this.date_horaFinal.CustomFormat = "HH:mm";
            this.date_horaFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_horaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_horaFinal.Location = new System.Drawing.Point(58, 127);
            this.date_horaFinal.Name = "date_horaFinal";
            this.date_horaFinal.ShowUpDown = true;
            this.date_horaFinal.Size = new System.Drawing.Size(271, 20);
            this.date_horaFinal.TabIndex = 9;
            this.date_horaFinal.ValueChanged += new System.EventHandler(this.Event_verificarConflitos);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dg_contatos);
            this.groupBox1.Controls.Add(this.cb_incluirContato);
            this.groupBox1.Location = new System.Drawing.Point(19, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contato";
            // 
            // dg_contatos
            // 
            this.dg_contatos.AllowUserToAddRows = false;
            this.dg_contatos.AllowUserToDeleteRows = false;
            this.dg_contatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_contatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_contatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_id,
            this.cl_nome,
            this.cl_email,
            this.cl_telefone,
            this.cl_empresa,
            this.cl_cargo});
            this.dg_contatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dg_contatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_contatos.Enabled = false;
            this.dg_contatos.Location = new System.Drawing.Point(3, 33);
            this.dg_contatos.MultiSelect = false;
            this.dg_contatos.Name = "dg_contatos";
            this.dg_contatos.ReadOnly = true;
            this.dg_contatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_contatos.Size = new System.Drawing.Size(323, 103);
            this.dg_contatos.TabIndex = 1;
            // 
            // cl_id
            // 
            this.cl_id.HeaderText = "Id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ReadOnly = true;
            // 
            // cl_nome
            // 
            this.cl_nome.HeaderText = "Nome";
            this.cl_nome.Name = "cl_nome";
            this.cl_nome.ReadOnly = true;
            // 
            // cl_email
            // 
            this.cl_email.HeaderText = "Email";
            this.cl_email.Name = "cl_email";
            this.cl_email.ReadOnly = true;
            // 
            // cl_telefone
            // 
            this.cl_telefone.HeaderText = "Telefone";
            this.cl_telefone.Name = "cl_telefone";
            this.cl_telefone.ReadOnly = true;
            // 
            // cl_empresa
            // 
            this.cl_empresa.HeaderText = "Empresa";
            this.cl_empresa.Name = "cl_empresa";
            this.cl_empresa.ReadOnly = true;
            // 
            // cl_cargo
            // 
            this.cl_cargo.HeaderText = "Cargo";
            this.cl_cargo.Name = "cl_cargo";
            this.cl_cargo.ReadOnly = true;
            // 
            // cb_incluirContato
            // 
            this.cb_incluirContato.AutoSize = true;
            this.cb_incluirContato.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_incluirContato.Location = new System.Drawing.Point(3, 16);
            this.cb_incluirContato.Name = "cb_incluirContato";
            this.cb_incluirContato.Size = new System.Drawing.Size(323, 17);
            this.cb_incluirContato.TabIndex = 0;
            this.cb_incluirContato.Text = "Incluir contato";
            this.cb_incluirContato.UseVisualStyleBackColor = true;
            this.cb_incluirContato.CheckedChanged += new System.EventHandler(this.Event_cb_incluirContato_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_cancelar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_concluir, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(19, 387);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(326, 49);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancelar.Location = new System.Drawing.Point(8, 8);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(8);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(147, 33);
            this.btn_cancelar.TabIndex = 0;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.Event_btn_cancelar_Click);
            // 
            // btn_concluir
            // 
            this.btn_concluir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_concluir.Location = new System.Drawing.Point(171, 8);
            this.btn_concluir.Margin = new System.Windows.Forms.Padding(8);
            this.btn_concluir.Name = "btn_concluir";
            this.btn_concluir.Size = new System.Drawing.Size(147, 33);
            this.btn_concluir.TabIndex = 1;
            this.btn_concluir.Text = "Concluir";
            this.btn_concluir.UseVisualStyleBackColor = true;
            this.btn_concluir.Click += new System.EventHandler(this.Event_btn_concluir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(363, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // DialogCompromissosCriar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 465);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "DialogCompromissosCriar";
            this.Text = "DialogCompromissosCriar";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_contatos)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_assunto;
        private System.Windows.Forms.TextBox text_local;
        private System.Windows.Forms.DateTimePicker date_data;
        private System.Windows.Forms.DateTimePicker date_horaInicial;
        private System.Windows.Forms.DateTimePicker date_horaFinal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_incluirContato;
        private System.Windows.Forms.DataGridView dg_contatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_cargo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_concluir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}