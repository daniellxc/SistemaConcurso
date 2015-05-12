using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stack_concurso.forms.cenarios.common
{
    public partial class header : UserControl
    {
        public header()
        {
            InitializeComponent();
            bindComponents();
            screenAdjust();
        }

        private void bindComponents()
        {
            lbl_empresa.Text = domain.Acessorios.GlobalConfiguration.empresa;
            lbl_empresa_descricao.Text = domain.Acessorios.GlobalConfiguration.empresa_descricao;
        }

        protected void screenAdjust()
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }

        public void headerName(string name)
        {
            lbl_topo.Text = name;
        }

        public void nonHeader()
        {
            this.Height = 0;
        }
    }
}
