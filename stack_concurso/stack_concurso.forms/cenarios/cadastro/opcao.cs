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
using System.Collections;

namespace stack_concurso.forms.cenarios.cadastro
{
    public partial class opcao : cenarios.common.masterPage
    {
        public opcao()
        {
            InitializeComponent();
            BindItens();
            screenAdjust();
            headerName("Cadastro", "Opção");
        }


        #region Métodos

        private void BindConcursos()
        {
            cmbConcurso.DataSource = new ConcursoBO().GetAll().Where(c=>c.ativo == true);
        }

        private void BindCidades()
        {
            cmbCidade.DataSource = new MunicipioBO().GetAll().OrderBy(m => m.nome_cidade);

        }

        private void BindCargos()
        {
            cmbCargo.DataSource = new CargoBO().GetAll().OrderBy(c => c.descricao);
        }

        private void BindGridCargos()
        {
            gridOpcoes.AutoGenerateColumns = false;
            var query = new OpcaoBO().GetOpcoesDoConcurso(int.Parse(cmbConcurso.SelectedValue.ToString()));

            gridOpcoes.DataSource = query;

        }

        private void BindItens()
        {
            BindConcursos();
            BindCargos();
            BindCidades();
            BindGridCargos();
        }

        private bool JaExisteOpacao(int cod_concurso,int cargo, int cidade, string codigo)
        {
            return new OpcaoBO().Find(o => o.cod_cargo == cargo && o.cod_concurso == cod_concurso && o.cod_cidade == cidade && o.codigo_identificador == codigo).ToList().Count > 0;
        }

        private void SalvarOpcao()
        {
            tb_opcao _novaOpcao = new tb_opcao();

            _novaOpcao.cod_cargo = int.Parse(cmbCargo.SelectedValue.ToString());
            _novaOpcao.cod_cidade = int.Parse(cmbCidade.SelectedValue.ToString());
            _novaOpcao.cod_concurso = int.Parse(cmbConcurso.SelectedValue.ToString());
            _novaOpcao.codigo_identificador = edtCodigo.Text;
            _novaOpcao.vagas = int.Parse(edtVagas.Text);

            if(JaExisteOpacao(_novaOpcao.cod_concurso,_novaOpcao.cod_cargo,_novaOpcao.cod_cidade,_novaOpcao.codigo_identificador)) throw new Exception("Opção já cadastrada.");

            new OpcaoBO().Salvar(_novaOpcao);

        }

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarOpcao();
                refresh(this);
                BindGridCargos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void gridOpcoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridOpcoes.CurrentCell.Value.ToString() == "excluir")
                {
                    ExcluirOpcao(int.Parse(gridOpcoes.CurrentRow.Cells[0].Value.ToString()));
                    BindGridCargos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
          
        }

        private void ExcluirOpcao(int cod_opcao)
        {
            try
            {
                tb_opcao opcao = new OpcaoBO().Find(o => o.cod_opcao == cod_opcao).First<tb_opcao>();
                new OpcaoBO().Deletar(opcao);
            }
            catch
            {
                throw new Exception("O registro não pode ser excluido pois está em uso.");
            }
        }

      
    }
}
