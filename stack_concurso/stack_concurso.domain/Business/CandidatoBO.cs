using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Modelo;
using stack_concurso.domain.Acessorios;

namespace stack_concurso.domain.Business
{
    public class CandidatoBO
    {
        #region DAO

        CandidatoDAO _DAO = GenericSingleton<CandidatoDAO>.GetInstance();

        public void Salvar(tb_candidato _candidato)
        {
            try
            {
                _DAO.Add(_candidato);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar candidato." + ex.Message);
            }
        }

        public void Atualizar()
        {
            try
            {
                _DAO.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar candidato." + e.Message);
            }
        }

        public void Deletar(tb_candidato _candidato)
        {
            try
            {
                _candidato = _DAO.Find(c => c.cod_candidato == _candidato.cod_candidato).First<tb_candidato>();
                _DAO.Delete(_candidato);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir o candidato." + ex.Message);
            }
        }

        public IQueryable<tb_candidato> Find(System.Linq.Expressions.Expression<Func<tb_candidato, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_candidato> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion


        public bool CandidatoExistente(string cpf, string rg)
        {
            return Find(c => c.rg.Equals(rg) || c.cpf.Equals(cpf)).ToList().Count > 0;

        }

        public IQueryable<tb_candidato> CandidatosConcurso(int concurso)
        {
            entidades context = new Contexto().GetContexto();
            var query = from a in context.tb_candidato
                        join b in context.tb_opcao on a.cod_opcao equals b.cod_opcao
                        where b.cod_concurso == concurso
                        select a;
            return query;
        }

        public IQueryable ImprimirInscricao(int candidato)
        {
            entidades context = new Contexto().GetContexto();
            var query = from a in context.tb_candidato
                        join b in context.tb_opcao on a.cod_opcao equals b.cod_opcao
                        join c in context.tb_cargo on b.cod_cargo equals c.cod_cargo
                        join d in context.tb_municipio on a.cod_cidade equals d.cod_municipio
                        join e in context.tb_municipio on a.naturalidade equals e.cod_municipio
                        join f in context.tb_municipio on b.cod_cidade equals f.cod_municipio
                        join g in context.tb_nivel_escolaridade on c.cod_nivel equals g.cod_nivel
                        where a.cod_candidato == candidato
                        select new
                        {
                            nome = a.nome,
                            data_nascimento = a.data_nascimento,
                            naturalidade = a.naturalidade,
                            uf = a.uf,
                            sexo = a.sexo,
                            estado_civil = a.estado_civil,
                            nome_pai = a.nome_pai,
                            nome_mae = a.nome_mae,
                            endereco = a.endereco,
                            numero = a.numero,
                            bairro = a.bairro,
                            cep = a.cep,
                            telefone = a.telefone,
                            celular = a.celular,
                            email = a.email,
                            cpf = a.cpf,
                            rg = a.rg,
                            orgao_rg = a.orgao_rg + "/" + a.uf_rg,
                            deficiencia = a.deficiencia,
                            atendimento_especial = a.atendimento_especial,
                            obs_atendimento = a.obs_atendiemento_especial,
                            nome_cidade = d.nome_cidade,
                            nome_opcao = c.descricao,
                            cod_cargo = b.codigo_identificador,
                            nome_naturalidade = e.nome_cidade,
                            observacao = a.observacao,
                            nome_cidade_cargo = f.nome_cidade,
                            escolaridade = g.descricao_nivel,
                            data_inscricao = a.data_inscricao
                        };
            return query;
        }

        public List<tb_candidato> buscarCandidato(string inscricao)
        {
            return Find(c => c.num_inscricao.Equals(inscricao)).ToList<tb_candidato>();
        }



        public void atribuir_falta(tb_candidato candidato, bool falta)
        {
            tb_candidato _candidato = Find(c => c.cod_candidato == candidato.cod_candidato).First<tb_candidato>();
            _candidato.falta = falta?1:0;
            Atualizar();

        }

        public bool apagar_respostas(int cod_candidato)
        {
            tb_candidato _candidato = Find(c => c.cod_candidato == cod_candidato).First<tb_candidato>();
            try
            {
                foreach (tb_resposta resp in _candidato.tb_resposta)
                {
                    RespostaBO respBO = new RespostaBO();
                    respBO.Deletar(resp);

                }
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
