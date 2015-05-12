using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.domain.Business;
using stack_concurso.domain.Modelo;

namespace stack_concurso.forms.cenarios.consulta
{
    public partial class consulta_candidato : cenarios.common.masterPage
    {
        public consulta_candidato()
        {
            InitializeComponent();
            screenAdjust();
            headerName("Consulta", "Candidato");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BindGridCandidatos();
        }

        private void BindGridCandidatos()
        {
            gridCandidatos.AutoGenerateColumns = false;
            gridCandidatos.DataSource = new CandidatoBO().Find(c => c.nome.Contains(edtNomeCandidato.Text)).ToList<tb_candidato>();
                
        }

       

        private void gridCandidatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCandidatos.CurrentCell.Value.ToString() == "selecionar")
            {
                tb_candidato candidato = gridCandidatos.CurrentRow.DataBoundItem as tb_candidato;
                candidato c = new candidato(candidato);
               
                panelAdd(c, panel1);

            }

        }

    }
}
