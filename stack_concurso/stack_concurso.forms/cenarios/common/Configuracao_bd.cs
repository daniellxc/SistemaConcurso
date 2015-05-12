using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.forms.cenarios.common
{
    public partial class Configuracao_bd : Form
    {
        public Configuracao_bd()
        {
            InitializeComponent();
            GlobalConfiguration _global_configuration = GenericSingleton<GlobalConfiguration>.GetInstance();
            _global_configuration.getBDPath(Application.StartupPath);
            edtIP.Text = _global_configuration.Bd_server_path;
            edtLogin.Text = _global_configuration.Bd_server_login;
            edtSenha.Text = _global_configuration.Bd_server_password;
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            GlobalConfiguration _global_configuration = GenericSingleton<GlobalConfiguration>.GetInstance();
            _global_configuration.Bd_server_path = edtIP.Text;
            _global_configuration.Bd_server_login = edtLogin.Text;
            _global_configuration.Bd_server_password = edtSenha.Text;
            _global_configuration.setBDPath(Application.StartupPath);
            //entidades contexto = new Contexto().GetContexto();
            entidades contexto = GenericSingleton<entidades>.GetInstance();
            contexto = new entidades(new Connection().getConnection());
            this.Close();
        }
    }
}
