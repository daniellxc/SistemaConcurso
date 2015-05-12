namespace stack_concurso.forms
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inscriçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarCadernosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.destinoBancoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this._save_file = new System.Windows.Forms.SaveFileDialog();
            this.leituraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscriçãoToolStripMenuItem,
            this.consultaToolStripMenuItem,
            this.cadastroToolStripMenuItem,
            this.arquivoToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 500;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inscriçãoToolStripMenuItem
            // 
            this.inscriçãoToolStripMenuItem.Name = "inscriçãoToolStripMenuItem";
            this.inscriçãoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.inscriçãoToolStripMenuItem.Text = "Inscrição";
            this.inscriçãoToolStripMenuItem.Click += new System.EventHandler(this.inscriçãoToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.candidatoToolStripMenuItem});
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // candidatoToolStripMenuItem
            // 
            this.candidatoToolStripMenuItem.Name = "candidatoToolStripMenuItem";
            this.candidatoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.candidatoToolStripMenuItem.Text = "Candidato";
            this.candidatoToolStripMenuItem.Click += new System.EventHandler(this.candidatoToolStripMenuItem_Click);
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradeToolStripMenuItem,
            this.provaToolStripMenuItem,
            this.opçãoToolStripMenuItem,
            this.criarCadernosToolStripMenuItem,
            this.leituraToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // gradeToolStripMenuItem
            // 
            this.gradeToolStripMenuItem.Name = "gradeToolStripMenuItem";
            this.gradeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gradeToolStripMenuItem.Text = "Cargo";
            this.gradeToolStripMenuItem.Click += new System.EventHandler(this.gradeToolStripMenuItem_Click);
            // 
            // provaToolStripMenuItem
            // 
            this.provaToolStripMenuItem.Name = "provaToolStripMenuItem";
            this.provaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.provaToolStripMenuItem.Text = "Prova";
            this.provaToolStripMenuItem.Click += new System.EventHandler(this.provaToolStripMenuItem_Click);
            // 
            // opçãoToolStripMenuItem
            // 
            this.opçãoToolStripMenuItem.Name = "opçãoToolStripMenuItem";
            this.opçãoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.opçãoToolStripMenuItem.Text = "Opção";
            this.opçãoToolStripMenuItem.Click += new System.EventHandler(this.opcaoToolStripMenuItem_Click);
            // 
            // criarCadernosToolStripMenuItem
            // 
            this.criarCadernosToolStripMenuItem.Name = "criarCadernosToolStripMenuItem";
            this.criarCadernosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.criarCadernosToolStripMenuItem.Text = "Criar Cadernos";
            this.criarCadernosToolStripMenuItem.Click += new System.EventHandler(this.criarCadernosToolStripMenuItem_Click);
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarArquivoToolStripMenuItem,
            this.exportarArquivoToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // gerarArquivoToolStripMenuItem
            // 
            this.gerarArquivoToolStripMenuItem.Name = "gerarArquivoToolStripMenuItem";
            this.gerarArquivoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.gerarArquivoToolStripMenuItem.Text = "Gerar Arquivo";
            this.gerarArquivoToolStripMenuItem.Click += new System.EventHandler(this.gerarArquivoToolStripMenuItem_Click);
            // 
            // exportarArquivoToolStripMenuItem
            // 
            this.exportarArquivoToolStripMenuItem.Name = "exportarArquivoToolStripMenuItem";
            this.exportarArquivoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exportarArquivoToolStripMenuItem.Text = "Enviar Arquivo";
            this.exportarArquivoToolStripMenuItem.Visible = false;
            this.exportarArquivoToolStripMenuItem.Click += new System.EventHandler(this.exportarArquivoToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem1,
            this.destinoBancoToolStripMenuItem});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.exportarToolStripMenuItem.Text = "Configurações";
            // 
            // exportarToolStripMenuItem1
            // 
            this.exportarToolStripMenuItem1.Name = "exportarToolStripMenuItem1";
            this.exportarToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.exportarToolStripMenuItem1.Text = "Exportar Arquivo";
            this.exportarToolStripMenuItem1.Visible = false;
            this.exportarToolStripMenuItem1.Click += new System.EventHandler(this.exportarToolStripMenuItem1_Click);
            // 
            // destinoBancoToolStripMenuItem
            // 
            this.destinoBancoToolStripMenuItem.Name = "destinoBancoToolStripMenuItem";
            this.destinoBancoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.destinoBancoToolStripMenuItem.Text = "Configurar Banco";
            this.destinoBancoToolStripMenuItem.Click += new System.EventHandler(this.destinoBancoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackgroundImage = global::stack_concurso.forms.Properties.Resources.main_background;
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 24);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(794, 547);
            this.pnlContent.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUsuarioLogado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 530);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 17);
            this.panel1.TabIndex = 1;
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.AutoSize = true;
            this.lblUsuarioLogado.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioLogado.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUsuarioLogado.Location = new System.Drawing.Point(759, 0);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUsuarioLogado.Size = new System.Drawing.Size(35, 13);
            this.lblUsuarioLogado.TabIndex = 0;
            this.lblUsuarioLogado.Text = "label1";
            // 
            // _save_file
            // 
            this._save_file.FileOk += new System.ComponentModel.CancelEventHandler(this._save_file_FileOk);
            // 
            // leituraToolStripMenuItem
            // 
            this.leituraToolStripMenuItem.Name = "leituraToolStripMenuItem";
            this.leituraToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.leituraToolStripMenuItem.Text = "Leitura";
            this.leituraToolStripMenuItem.Click += new System.EventHandler(this.leituraToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 571);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sistemas de Processo Seletivo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inscriçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provaToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStripMenuItem opçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem destinoBancoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candidatoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarArquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarArquivoToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog _save_file;
        private System.Windows.Forms.ToolStripMenuItem criarCadernosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leituraToolStripMenuItem;

    }
}

