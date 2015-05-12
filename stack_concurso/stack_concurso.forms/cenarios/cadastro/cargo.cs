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

namespace stack_concurso.forms.cenarios.cadastro
{
    public partial class cargo : cenarios.common.masterPage
    {
        public cargo()
        {
            InitializeComponent();
            BindItens();
            screenAdjust();
            headerName("Cadastro", "Cargo");
        }

       

        #region Métodos

        private void BindEscolaridade()
        {

           cmbEscolaridade.DataSource  = new NivelEscolaridadeBO().GetAll().OrderBy(e=>e.descricao_nivel);

        }

        private void BindGrade()
        {
            cmbGrade.DataSource = new GradeBO().GetAll().OrderBy(g => g.descricao_grade);
        }

        private void BindItens()
        {
            BindGrade();
            BindEscolaridade();
        }

        private void SalvarCargo()
        {
            tb_cargo _novoCargo = new tb_cargo();

            _novoCargo.descricao = edtDescricaoCargo.Text;
            _novoCargo.cod_grade = int.Parse(cmbGrade.SelectedValue.ToString());
            _novoCargo.cod_nivel = int.Parse(cmbEscolaridade.SelectedValue.ToString());

            new CargoBO().Salvar(_novoCargo);


        }

        private bool JaExisteCargo()
        {

            return new CargoBO().Find(c => c.descricao.Equals(edtDescricaoCargo.Text)).ToList().Count > 0;
        }

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (JaExisteCargo()) throw new Exception("Este cargo já existe.");
                SalvarCargo();
                refresh(this);
            }
            catch (Exception ex)
            {

            }
        }

     

      
    }
}
