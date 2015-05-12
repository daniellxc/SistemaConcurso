namespace stack_concurso.forms.cenarios.leitura
{
    partial class FLeituraArquivo
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
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.gridErros = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btConferir = new System.Windows.Forms.Button();
            this.btCorrigir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridErros)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(129, 47);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(267, 20);
            this.txtArquivo.TabIndex = 0;
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(402, 44);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 23);
            this.btnProcurar.TabIndex = 1;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // gridErros
            // 
            this.gridErros.AllowUserToAddRows = false;
            this.gridErros.AllowUserToDeleteRows = false;
            this.gridErros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridErros.Location = new System.Drawing.Point(13, 99);
            this.gridErros.Name = "gridErros";
            this.gridErros.ReadOnly = true;
            this.gridErros.Size = new System.Drawing.Size(660, 309);
            this.gridErros.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btConferir);
            this.panel1.Controls.Add(this.btCorrigir);
            this.panel1.Location = new System.Drawing.Point(13, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 60);
            this.panel1.TabIndex = 5;
            // 
            // btConferir
            // 
            this.btConferir.Location = new System.Drawing.Point(3, 21);
            this.btConferir.Name = "btConferir";
            this.btConferir.Size = new System.Drawing.Size(134, 23);
            this.btConferir.TabIndex = 1;
            this.btConferir.Text = "Conferir Cartões";
            this.btConferir.UseVisualStyleBackColor = true;
            this.btConferir.Click += new System.EventHandler(this.btConferir_Click);
            // 
            // btCorrigir
            // 
            this.btCorrigir.Location = new System.Drawing.Point(143, 21);
            this.btCorrigir.Name = "btCorrigir";
            this.btCorrigir.Size = new System.Drawing.Size(130, 23);
            this.btCorrigir.TabIndex = 0;
            this.btCorrigir.Text = "Corrigir Cartões";
            this.btCorrigir.UseVisualStyleBackColor = true;
            this.btCorrigir.Click += new System.EventHandler(this.btCorrigir_Click);
            // 
            // FLeituraArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 481);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridErros);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.txtArquivo);
            this.Name = "FLeituraArquivo";
            this.Text = "FLeituraArquivo";
            ((System.ComponentModel.ISupportInitialize)(this.gridErros)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.DataGridView gridErros;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btConferir;
        private System.Windows.Forms.Button btCorrigir;
    }
}