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
using stack_concurso.forms.acessorio;
using System.Transactions;

namespace stack_concurso.forms.cenarios.consulta
{
    public partial class candidato : UserControl
    {
        public candidato()
        {
            InitializeComponent();
            BindItens();
            screenAdjust();
            if (CandidatoAux != null)
                Editando();
            
        }


        public candidato(tb_candidato _candidato)
        {
            InitializeComponent();
            BindItens();
            screenAdjust();
            CandidatoAux = _candidato;
            if (CandidatoAux != null)
                Editando();
        }

        

        private tb_candidato _CandidatoAux;
        private CandidatoBO candidato_bo = new CandidatoBO();

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
           
            BindUf();
            BindDeficiencia();
            BindNaturalDe();
           // BindCargos(int.Parse(cmbConcurso.SelectedValue.ToString()));

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
            try
            {
                edtCodigoCargo.Text = new OpcaoBO().Find(op => op.cod_cargo == codCargo && op.cod_cidade == codCidade).First<tb_opcao>().codigo_identificador.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void InstaciarCandidato(int cod_candidato)
        {      
           
            CandidatoAux = candidato_bo.Find(c => c.cod_candidato == cod_candidato).First<tb_candidato>();
            CandidatoAux.atendimento_especial = cmbAtendimentoEsp.SelectedItem == "SIM";
            CandidatoAux.bairro = edtBairro.Text;
            CandidatoAux.celular = edtCelular.Text;
            CandidatoAux.cep = edtCep.Text;
            CandidatoAux.cod_cidade = int.Parse(cmbCidade.SelectedValue.ToString());
            CandidatoAux.cod_opcao = Int32.Parse(edtCodigoCargo.Text);
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
            CandidatoAux.cod_opcao = new OpcaoBO().Find(o=>o.codigo_identificador == edtCodigoCargo.Text).First<tb_opcao>().cod_opcao;
            CandidatoAux.rg = edtRg.Text;
            CandidatoAux.sexo = cmbSexo.SelectedItem.ToString();
            CandidatoAux.telefone = edtTelefone.Text;
            CandidatoAux.uf = (cmbUfNascimento.SelectedItem as tb_uf).sigla;
            CandidatoAux.uf_rg = (cmbUfRg.SelectedItem as tb_uf).sigla;
            CandidatoAux.obs_atendiemento_especial = edtObsAtend.Text;
            candidato_bo.Atualizar();
        }

        private void AtualizarCandidato()
        {
           
                try
                {
                    InstaciarCandidato(CandidatoAux.cod_candidato);
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
            MessageBox.Show("Cadastro foi salvo com sucesso!","Sucesso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        #endregion

        private void cmbUfNascimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCidade(int.Parse(cmbUfNascimento.SelectedValue.ToString()));
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCidadeCargo.DataSource = new OpcaoBO().GetCidadesDoCargo(int.Parse(cmbCargo.SelectedValue.ToString()), CandidatoAux.tb_opcao.cod_concurso);
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

        private void btnMostrarInscricao_Click(object sender, EventArgs e)
        {
           // int cod_candidato = Int32.Parse(cmbCandidato.SelectedValue.ToString());
            if (Sessao.UsuarioLogado.admin)
            {
                InstaciarCandidato(CandidatoAux.cod_candidato);
                MostraConfirmacaoInscricao(CandidatoAux.cod_candidato);
            }
            else
            {
                MessageBox.Show("Os dados não foram alterados. Para alteração nos dados contate um administrador.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MostraConfirmacaoInscricao(CandidatoAux.cod_candidato);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Sessao.UsuarioLogado.admin)
            {
                try
                {
                    AtualizarCandidato();
                    btnFinalizar.Enabled = true;
                    FinalizarInscricao();
                   
                }
                catch (Exception ex)
                {

                    CandidatoAux = null;
                    MessageBox.Show(ex.Message);
                }
               
            }
            else
                MessageBox.Show("Você não tem permissão editar candidatos.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void cmbCandidato_SelectedIndexChanged(object sender, EventArgs e)
        {
           //// bindAll();
           // if(cmbCandidato.SelectedValue!=null)
           //      Editando();
        }

        private void Editando()
        {
            
            //CandidatoAux = new CandidatoBO().Find(c => c.cod_candidato == codCanditato).First<tb_candidato>();

            edtBairro.Text = CandidatoAux.bairro;
            edtCelular.Text = CandidatoAux.celular;
            edtCep.Text = CandidatoAux.cep;
            edtComplemento.Text = CandidatoAux.complemento;
            edtCpf.Text = CandidatoAux.cpf;
            edtDataNascimento.Text = CandidatoAux.data_nascimento.ToShortDateString();
            edtEmail.Text = CandidatoAux.email;
            edtEndereco.Text = CandidatoAux.endereco;
            edtNomeCandidato.Text = CandidatoAux.nome;
            edtNomeMae.Text = CandidatoAux.nome_mae;
            edtNomePai.Text = CandidatoAux.nome_pai;
            edtNum.Text = CandidatoAux.numero;
            edtObsAtend.Text = CandidatoAux.obs_atendiemento_especial;
            edtObsDef.Text = CandidatoAux.observacao;
            edtOrgExp.Text = CandidatoAux.orgao_rg;
            edtRg.Text = CandidatoAux.rg;
            edtTelefone.Text = CandidatoAux.telefone;

            if (CandidatoAux.atendimento_especial)
                cmbAtendimentoEsp.SelectedItem = "SIM";
            else cmbAtendimentoEsp.SelectedItem = "NÃO";

            cmbDeficiencia.SelectedValue = CandidatoAux.deficiencia;

            cmbUfNascimento.SelectedIndex = cmbUfNascimento.FindString(CandidatoAux.uf);
            BindCidade(Int32.Parse(cmbUfNascimento.SelectedValue.ToString()));
            cmbCidade.SelectedValue = CandidatoAux.cod_cidade;
            cmbEstadoCivil.SelectedItem = CandidatoAux.estado_civil;
            cmbNaturalidade.SelectedValue = CandidatoAux.naturalidade;
            cmbSexo.SelectedItem = CandidatoAux.sexo;
            cmbUfRg.SelectedIndex = cmbUfRg.FindString(CandidatoAux.uf_rg);

            ExibeObsAtendimentoEspecial(CandidatoAux.atendimento_especial);
            if (CandidatoAux.deficiencia == "N") ExibeObsDeficiencia(false);
            else ExibeObsDeficiencia(true);
            BindCargos(CandidatoAux.tb_opcao.cod_concurso);
            cmbCargo.SelectedValue = CandidatoAux.tb_opcao.cod_cargo;
            edtCodigoCargo.Text = CandidatoAux.tb_opcao.codigo_identificador;
            cmbCidadeCargo.SelectedValue = CandidatoAux.tb_opcao.cod_cidade;
        }
        
        protected void screenAdjust()
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
        }
    }
}
