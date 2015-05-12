using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.forms.acessorio;

namespace stack_concurso.forms.cenarios.leitura
{
    public partial class FLeituraArquivo : Form
    {

        private Leitura leitura;
        public FLeituraArquivo()
        {
            InitializeComponent();
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Le os arquivos selecionados 

                txtArquivo.Text = openFileDialog1.FileName;

                leitura = new Leitura(txtArquivo.Text);

                if (leitura.erros.Count > 0)
                {
                    gridErros.DataSource = leitura.erros;
                    gridErros.Visible = true;

                }

                //panel1.Visible = true;

            }
        }

        private void btConferir_Click(object sender, EventArgs e)
        {

            if (leitura.conferir_cartoes())
            {
                MessageBox.Show("Nenhum problema!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

              //  btCorrigir.Enabled = true;
            }
            else
            {
                gridErros.DataSource = leitura.erros;
                gridErros.Visible = true;

            }
       
        }

        private void btCorrigir_Click(object sender, EventArgs e)
        {
            if (leitura.corrigir_questoes())
            {
                MessageBox.Show("Questões corrigidas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                MessageBox.Show("Não foi possível concluir a operação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
