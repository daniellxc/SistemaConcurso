namespace stack_concurso.forms.cenarios.common
{
    partial class header
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
            this.lbl_topo = new System.Windows.Forms.Label();
            this.lbl_empresa_descricao = new System.Windows.Forms.Label();
            this.lbl_empresa = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_topo
            // 
            this.lbl_topo.AutoSize = true;
            this.lbl_topo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_topo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_topo.Location = new System.Drawing.Point(2, 72);
            this.lbl_topo.Name = "lbl_topo";
            this.lbl_topo.Size = new System.Drawing.Size(61, 22);
            this.lbl_topo.TabIndex = 97;
            this.lbl_topo.Text = "$Tela";
            // 
            // lbl_empresa_descricao
            // 
            this.lbl_empresa_descricao.AutoSize = true;
            this.lbl_empresa_descricao.BackColor = System.Drawing.Color.Transparent;
            this.lbl_empresa_descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_empresa_descricao.Location = new System.Drawing.Point(179, 31);
            this.lbl_empresa_descricao.Name = "lbl_empresa_descricao";
            this.lbl_empresa_descricao.Size = new System.Drawing.Size(46, 17);
            this.lbl_empresa_descricao.TabIndex = 96;
            this.lbl_empresa_descricao.Text = "label1";
            // 
            // lbl_empresa
            // 
            this.lbl_empresa.AutoSize = true;
            this.lbl_empresa.BackColor = System.Drawing.Color.Transparent;
            this.lbl_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_empresa.Location = new System.Drawing.Point(179, 14);
            this.lbl_empresa.Name = "lbl_empresa";
            this.lbl_empresa.Size = new System.Drawing.Size(52, 17);
            this.lbl_empresa.TabIndex = 95;
            this.lbl_empresa.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::stack_concurso.forms.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 94;
            this.pictureBox1.TabStop = false;
            // 
            // header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::stack_concurso.forms.Properties.Resources.main_background;
            this.Controls.Add(this.lbl_topo);
            this.Controls.Add(this.lbl_empresa_descricao);
            this.Controls.Add(this.lbl_empresa);
            this.Controls.Add(this.pictureBox1);
            this.Enabled = false;
            this.Name = "header";
            this.Size = new System.Drawing.Size(546, 108);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_topo;
        private System.Windows.Forms.Label lbl_empresa_descricao;
        private System.Windows.Forms.Label lbl_empresa;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
