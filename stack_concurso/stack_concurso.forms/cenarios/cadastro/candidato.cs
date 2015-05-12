using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Business;
using stack_concurso.domain.Modelo;
using System.Transactions;
using stack_concurso.forms.acessorio;

namespace stack_concurso.forms.cenarios.cadastro
{
    public partial class candidato : cenarios.common.masterPage
    {
        public candidato()
        {
            InitializeComponent();
            BindItens();
            lbl_processo_nome.Text = "Informações sobre: " + cmbConcurso.Text;
            screenAdjust();
            headerName("Cadastro","Candidato");
            _CandidatoAux = null;
        }

        private tb_candidato _CandidatoAux;

        public tb_candidato CandidatoAux
        {
            get
            {
                return _CandidatoAux;
            }
            set
            {
                _CandidatoAux = value;
            }
        }

        public bool Edit()
        {
            return _CandidatoAux != null;
        }

        #region Métodos

        private void BindUf()
        {
            cmbUfRg.DataSource = new UfBO().GetAll().OrderBy(uf => uf.nome);
            cmbUfNascimento.DataSource = new UfBO().GetAll().OrderBy(uf => uf.nome);
        }

        private void BindNaturalDe()
        {
            cmbNaturalidade.DataSource = new MunicipioBO().GetAll().OrderBy(m => m.nome_cidade);
        }

        private void BindCidade(int cod_uf)
        {
            cmbCidade.DataSource = new MunicipioBO().Find(m => m.cod_uf == cod_uf).ToList<tb_municipio>();
        }

        private void BindConcurso()
        {
            cmbConcurso.DataSource = new ConcursoBO().GetAll().Where(c => c.ativo == true);
            cmbConcurso.SelectedIndex = 0;

        }

        private void BindCargos(int cod_concurso)
        {
            cmbCargo.DataSource = new OpcaoBO().GetOpcoes(cod_concurso);

        }

        private void BindDeficiencia()
        {
            cmbDeficiencia.DataSource = new DeficienciaBO().GetAll();

        }

        private void BindItens()
        {
            BindConcurso();
            BindUf();
            BindDeficiencia();
            BindNaturalDe();
            BindCargos(int.Parse(cmbConcurso.SelectedValue.ToString()));

        }

        private void ExibeObsDeficiencia(bool exibe)
        {
            edtObsDef.Visible = exibe;
            lblObsDef.Visible = exibe;
        }

        private void ExibeObsAtendimentoEspecial(bool exibe)
        {
            edtObsAtend.Visible = exibe;
            lblObsAtendimento.Visible = exibe;
        }

        private void PegarCodigoOpcao(int codCargo, int codCidade)
        {
            edtCodigoCargo.Text = new OpcaoBO().Find(op => op.cod_cargo == codCargo && op.cod_cidade == codCidade).First<tb_opcao>().codigo_identificador.ToString();
        }

        private void InstaciarCandidato()
        {
             if (Edit())
            {
                CandidatoAux = new CandidatoBO().Find(c => c.cod_candidato == CandidatoAux.cod_candidato).First<tb_candidato>();

            }
            else
                CandidatoAux = new tb_candidato();

            CandidatoAux.atendimento_especial = cmbAtendimentoEsp.SelectedItem == "SIM";
            CandidatoAux.bairro = edtBairro.Text;
            CandidatoAux.celular = edtCelular.Text;
            CandidatoAux.cep = edtCep.Text;
            CandidatoAux.cod_cidade = int.Parse(cmbCidade.SelectedValue.ToString());
            CandidatoAux.cod_opcao = (new OpcaoBO().Find(op => op.codigo_identificador == edtCodigoCargo.Text).First<tb_opcao>()).cod_opcao;
            CandidatoAux.complemento = edtComplemento.Text;
            CandidatoAux.cpf = edtCpf.Text;
            CandidatoAux.data_inscricao = DateTime.Now;
            CandidatoAux.data_nascimento = DateTime.Parse(edtDataNascimento.Text);
            CandidatoAux.deficiencia = cmbDeficiencia.SelectedValue.ToString();
            CandidatoAux.email = edtEmail.Text;
            CandidatoAux.endereco = edtEndereco.Text;
            CandidatoAux.estado_civil = cmbEstadoCivil.SelectedItem.ToString();
            CandidatoAux.naturalidade = int.Parse(cmbNaturalidade.SelectedValue.ToString());
            CandidatoAux.nome = edtNomeCandidato.Text;
            CandidatoAux.nome_mae = edtNomeMae.Text;
            CandidatoAux.nome_pai = edtNomePai.Text;
            CandidatoAux.num_inscricao = "0000000000";
            CandidatoAux.numero = edtNum.Text;
            CandidatoAux.observacao = edtObsDef.Text;
            CandidatoAux.orgao_rg = edtOrgExp.Text;
            CandidatoAux.rg = edtRg.Text;
            CandidatoAux.sexo = cmbSexo.SelectedItem.ToString();
            CandidatoAux.telefone = edtTelefone.Text;
            CandidatoAux.uf = (cmbUfNascimento.SelectedItem as tb_uf).sigla;
            CandidatoAux.uf_rg = (cmbUfRg.SelectedItem as tb_uf).sigla;
            CandidatoAux.obs_atendiemento_especial = edtObsAtend.Text;
        }

        private void SalvarCandidato()
        {

            InstaciarCandidato();
            if (new CandidatoBO().CandidatoExistente(CandidatoAux.cpf, CandidatoAux.rg)) throw new Exception("Já existe um candidato com mesmo RG ou CPF");

            try
            {
                new CandidatoBO().Salvar(CandidatoAux);

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        private void AtualizarCandidato()
        {
            InstaciarCandidato();
            try
            {
                new CandidatoBO().Atualizar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }


        private void MostraConfirmacaoInscricao(int codCandidato)
        {
            cenarios.relatorios.candidato_inscricao form = new cenarios.relatorios.candidato_inscricao(codCandidato);
            form.Visible = true;
        }

        private void FinalizarInscricao()
        {
            Util.ClearForm(this);
            btnFinalizar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        #endregion

        private void cmbUfNascimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCidade(int.Parse(cmbUfNascimento.SelectedValue.ToString()));
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCidadeCargo.DataSource = new OpcaoBO().GetCidadesDoCargo(int.Parse(cmbCargo.SelectedValue.ToString()),int.Parse(cmbConcurso.SelectedValue.ToString()));
        }

        private void cmbDeficiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeficiencia.SelectedValue.ToString() != "N")
                ExibeObsDeficiencia(true);
            else
            {
                ExibeObsDeficiencia(false);
                edtObsDef.Text = "";
            }
        }

        private void cmbAtendimentoEsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAtendimentoEsp.SelectedItem == "SIM")
                ExibeObsAtendimentoEspecial(true);
            else
            {
                ExibeObsAtendimentoEspecial(false);
                edtObsAtend.Text = "";
            }
        }

        private void cmbCidadeCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PegarCodigoOpcao(int.Parse(cmbCargo.SelectedValue.ToString()), int.Parse(cmbCidadeCargo.SelectedValue.ToString()));
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool sucesso = false;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    if (!Edit())
                    {

                        SalvarCandidato();

                    }
                    else
                        AtualizarCandidato();

                    sucesso = true;
                    btnFinalizar.Enabled = true;
                  
                    MostraConfirmacaoInscricao(CandidatoAux.cod_candidato);
                }
                catch (Exception ex)
                {
                    sucesso = false;
                    CandidatoAux = null;
                    MessageBox.Show(ex.Message);
                }
               
                if (sucesso)
                    scope.Complete();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            bool sucesso = false;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    if (!Edit())
                    {

                        SalvarCandidato();

                    }
                    else
                        AtualizarCandidato();

                    sucesso = true;
                    btnFinalizar.Enabled = true;
                    FinalizarInscricao();
                }
                catch (Exception ex)
                {
                    sucesso = false;
                    CandidatoAux = null;
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    CandidatoAux = null;
                }
                if (sucesso)
                    scope.Complete();
            }
        }

        private void cmbConcurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCargos(Int32.Parse(cmbConcurso.SelectedValue.ToString()));
            lbl_processo_nome.Text = "Informações sobre: " + cmbConcurso.Text;
        }

    }
}
