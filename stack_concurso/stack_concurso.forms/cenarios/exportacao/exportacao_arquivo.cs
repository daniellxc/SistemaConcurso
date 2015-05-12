using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.forms.cenarios.common;
using stack_concurso.forms.acessorio;

namespace stack_concurso.forms.cenarios.exportacao
{
    public partial class exportacao_arquivo : masterPage
    {
        public exportacao_arquivo()
        {
            InitializeComponent();
            screenAdjust();
            headerName("Exportação", "Arquivo");
           // EscolherPasta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EscolherPasta();
        }

        private void EscolherPasta()
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = folderBrowserDialog1.SelectedPath;
                btnExportar.Enabled = true;
            }
            else
            {
                btnExportar.Enabled = false;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.SelectedPath == "") throw new Exception("É preciso selecionar um diretório.");
            else
            {
                try
                {
                    ExportarArquivo(textBox1.Text);
                    MessageBox.Show("Exportação concluída.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }

        private void ExportarArquivo(string diretorio)
        {
            Util.ExportCandidatos(diretorio);
            textBox1.Text = "";
            
        }
    }
}
