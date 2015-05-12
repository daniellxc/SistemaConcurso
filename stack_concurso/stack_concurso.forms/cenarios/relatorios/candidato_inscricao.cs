using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.domain.Business;
using stack_concurso.domain.Modelo;
using Microsoft.Reporting.WinForms;

namespace stack_concurso.forms.cenarios.relatorios
{
    public partial class candidato_inscricao : Form
    {
        public candidato_inscricao(int candidato)
        {
            InitializeComponent();
            //IQueryable<tb_candidato> candidato_inscricao = new CandidatoBO().Find(a=> a.cod_candidato == candidato);
            IQueryable candidato_inscricao = new CandidatoBO().ImprimirInscricao(candidato);
            ReportDataSource dataSource = new ReportDataSource("Candidato", candidato_inscricao);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.Refresh();

        }

        private void candidato_inscricao_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
