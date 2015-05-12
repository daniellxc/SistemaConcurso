using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stack_concurso.forms.cenarios.cadastro
{
    public partial class prova : cenarios.common.masterPage
    {
        public prova()
        {
            InitializeComponent();
            screenAdjust();
            headerName("Cadastro", "Prova");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
