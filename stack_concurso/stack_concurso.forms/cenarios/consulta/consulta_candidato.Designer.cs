namespace stack_concurso.forms.cenarios.consulta
{
    partial class consulta_candidato
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.gridCandidatos = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.edtNomeCandidato = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCandidatos)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 562);
            this.panel1.TabIndex = 110;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.gridCandidatos);
            this.pnlContent.Controls.Add(this.panel3);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1051, 562);
            this.pnlContent.TabIndex = 4;
            // 
            // gridCandidatos
            // 
            this.gridCandidatos.AllowUserToAddRows = false;
            this.gridCandidatos.AllowUserToDeleteRows = false;
            this.gridCandidatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCandidatos.BackgroundColor = System.Drawing.Color.White;
            this.gridCandidatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCandidatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.Column1,
            this.Column2});
            this.gridCandidatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCandidatos.Location = new System.Drawing.Point(0, 41);
            this.gridCandidatos.Name = "gridCandidatos";
            this.gridCandidatos.ReadOnly = true;
            this.gridCandidatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridCandidatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCandidatos.Size = new System.Drawing.Size(1051, 521);
            this.gridCandidatos.TabIndex = 5;
            this.gridCandidatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCandidatos_CellClick);
            // 
            // cod
            // 
            this.cod.DataPropertyName = "cod_candidato";
            this.cod.FillWeight = 152.2843F;
            this.cod.HeaderText = "Cod.";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "nome";
            this.Column1.FillWeight = 73.85786F;
            this.Column1.HeaderText = "Nome";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 73.85786F;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Text = "selecionar";
            this.Column2.UseColumnTextForLinkValue = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.btnPesquisar);
            this.panel3.Controls.Add(this.edtNomeCandidato);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1051, 41);
            this.panel3.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(545, 10);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 3;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // edtNomeCandidato
            // 
            this.edtNomeCandidato.Location = new System.Drawing.Point(23, 10);
            this.edtNomeCandidato.Name = "edtNomeCandidato";
            this.edtNomeCandidato.Size = new System.Drawing.Size(516, 20);
            this.edtNomeCandidato.TabIndex = 2;
            // 
            // consulta_candidato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "consulta_candidato";
            this.Size = new System.Drawing.Size(1051, 661);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCandidatos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView gridCandidatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn Column2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox edtNomeCandidato;
    }
}
