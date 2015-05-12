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
    public partial class masterPage : UserControl
    {
        public masterPage()
        {
            InitializeComponent();
            panelAdd(new cenarios.common.header(),pnlHeader);         
        }

#region ajuste para painel
        protected void panelAdd(Object obj,Panel panel)
        {
            if (panel.Controls.Count == 1) panel.Controls.RemoveAt(0);
            panel.Controls.Add((Control)obj);

        }

        public static void refresh(Control c)
        {
            acessorio.Util.ClearForm(c);
        }

        protected void screenAdjust()
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height-50;
        }

        protected void headerName(string tipo, string nome)
        {
            ((common.header)pnlHeader.Controls["header"]).headerName(tipo+" de "+nome);
        }

        protected void nonHeader()
        {
            ((common.header)pnlHeader.Controls["header"]).nonHeader();
        }
#endregion

    }
}
