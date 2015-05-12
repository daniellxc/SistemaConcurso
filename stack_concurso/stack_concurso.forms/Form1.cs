using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.domain.Acessorios;
using stack_concurso.forms.acessorio;
using System.IO;

namespace stack_concurso.forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GlobalConfiguration _global_configuration = GenericSingleton<GlobalConfiguration>.GetInstance();
            _global_configuration.getBDPath(Application.StartupPath);
            try { lblUsuarioLogado.Text = "Login: " + Sessao.UsuarioLogado.nome_usuario; }
            catch { lblUsuarioLogado.Text = "Suporte Técnico"; }
            panelAdd(new cenarios.cadastro.criarProva(), pnlContent);
        }

#region ajuste para painel
        private void panelAdd(object objeto, Panel panel)
        {
           if (panel.Controls.Count == 1) panel.Controls.RemoveAt(0);
            panel.Controls.Add((Control)objeto);

        }
#endregion

        private void inscriçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdd(new cenarios.cadastro.candidato(), pnlContent);
        }

        private void gradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdd(new cenarios.cadastro.cargo(), pnlContent);
        }

        private void provaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdd(new cenarios.cadastro.prova(), pnlContent);
        }

        private void opcaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdd(new cenarios.cadastro.opcao(), pnlContent);
        }

        private void exportarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            acessorio.Util.ExportCandidatos();
            MessageBox.Show("Exportado com Sucesso!");
        }

        private void destinoBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenarios.common.Configuracao_bd form = new cenarios.common.Configuracao_bd();
            form.Visible = true;
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenarios.relatorios.candidato_inscricao a = new cenarios.relatorios.candidato_inscricao(2);
            a.Visible = true;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenarios.common.Confirmar_Sair form = new cenarios.common.Confirmar_Sair();
            form.Visible = true;
        }

        private void candidatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdd(new cenarios.consulta.consulta_candidato(), pnlContent);
        }

        private void gerarArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            _save_file.FileName = "Dados_Candidatos" + DateTime.Now.ToShortDateString().Replace('/','-');
            _save_file.Filter = "Processo Seletivo (*.pss)|*.pss";
            _save_file.ShowDialog();
            
            //panelAdd(new cenarios.exportacao.exportacao_arquivo(), pnlContent);
        }

        private void _save_file_FileOk(object sender, CancelEventArgs e)
        {
            acessorio.Util.ExportCandidatos(_save_file.FileName);
            MessageBox.Show("Exportado com Sucesso");
        }

        private void exportarArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void criarCadernosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdd(new cenarios.cadastro.criarProva(), pnlContent);
        }

        private void leituraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenarios.leitura.FLeituraArquivo form = new cenarios.leitura.FLeituraArquivo();
            form.Visible = true;
        }

       

      
    }
}
