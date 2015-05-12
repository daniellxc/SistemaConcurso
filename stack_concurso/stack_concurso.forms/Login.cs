using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.forms.cenarios.common;
using stack_concurso.domain.Modelo;
using stack_concurso.domain.Business;
using stack_concurso.forms.acessorio;
using stack_concurso.domain.Acessorios;

namespace stack_concurso.forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        //    headerName("Tela", "Login");
            GlobalConfiguration _global_configuration = GenericSingleton<GlobalConfiguration>.GetInstance();
            _global_configuration.getBDPath(Application.StartupPath);
            EfetuarLogin("daniel", "daniel");
        }

        protected void headerName(string tipo, string nome)
        {
            ((header)pnlHeader.Controls["header1"]).headerName(tipo + " de " + nome);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            EfetuarLogin(edtLogin.Text, edtSenha.Text);
        }

        private void EfetuarLogin(string login, string senha)
        {
            tb_usuario _usuarioLogado = new UsuarioBO().GetUsuario(login, senha);
            if (_usuarioLogado != null)
            {

                Sessao.UsuarioLogado = _usuarioLogado;
                new Form1().ShowDialog();
                this.Dispose();

            }
            else
                UsuarioInvalido();
        }

        private void UsuarioInvalido()
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Usuário ou senha incorretos.";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void destinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cenarios.common.Configuracao_bd form = new cenarios.common.Configuracao_bd();
            form.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
