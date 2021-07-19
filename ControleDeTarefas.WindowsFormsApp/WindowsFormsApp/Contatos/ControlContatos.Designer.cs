
namespace WindowsFormsApp.Contatos
{
    partial class ControlContatos
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
            this.dg_contatos = new System.Windows.Forms.DataGridView();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_criar = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_contatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dg_contatos);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 219);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contatos";
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
            this.dg_contatos.Location = new System.Drawing.Point(3, 16);
            this.dg_contatos.MultiSelect = false;
            this.dg_contatos.Name = "dg_contatos";
            this.dg_contatos.ReadOnly = true;
            this.dg_contatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_contatos.Size = new System.Drawing.Size(547, 200);
            this.dg_contatos.TabIndex = 0;
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(6, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funções";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_criar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_editar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_excluir, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(541, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_criar
            // 
            this.btn_criar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_criar.Location = new System.Drawing.Point(7, 7);
            this.btn_criar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_criar.Name = "btn_criar";
            this.btn_criar.Size = new System.Drawing.Size(166, 30);
            this.btn_criar.TabIndex = 0;
            this.btn_criar.Text = "Criar";
            this.btn_criar.UseVisualStyleBackColor = true;
            this.btn_criar.Click += new System.EventHandler(this.Event_btn_criar_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_editar.Location = new System.Drawing.Point(187, 7);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(7);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(166, 30);
            this.btn_editar.TabIndex = 1;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.Event_btn_editar_Click);
            // 
            // btn_excluir
            // 
            this.btn_excluir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_excluir.Location = new System.Drawing.Point(367, 7);
            this.btn_excluir.Margin = new System.Windows.Forms.Padding(7);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(167, 30);
            this.btn_excluir.TabIndex = 2;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.Evenet_btn_excluir_Click);
            // 
            // ControlContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ControlContatos";
            this.Size = new System.Drawing.Size(559, 294);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_contatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_contatos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_criar;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_cargo;
    }
}
