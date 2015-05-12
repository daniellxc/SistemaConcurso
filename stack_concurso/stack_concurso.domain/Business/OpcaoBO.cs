using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class OpcaoBO
    {
        #region DAO

        OpcaoDAO _DAO = GenericSingleton<OpcaoDAO>.GetInstance();

        public void Salvar(tb_opcao _opcao)
        {
            try
            {
                _DAO.Add(_opcao);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar opcao." + ex.Message);
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
                throw new Exception("Erro ao atualizar opcao." + e.Message);
            }
        }

        public void Deletar(tb_opcao _opcao)
        {
            try
            {
                _opcao = _DAO.Find(op => op.cod_opcao == _opcao.cod_opcao).First<tb_opcao>();
                _DAO.Delete(_opcao);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir opcao." + ex.Message);
            }
        }

        public IQueryable<tb_opcao> Find(System.Linq.Expressions.Expression<Func<tb_opcao, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_opcao> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion


        public IQueryable GetOpcoes(int cod_concurso)
        {
            entidades context = new Contexto().GetContexto();
            var query = ( from opcao in context.tb_opcao
                        join cargo in context.tb_cargo
                        on opcao.cod_cargo equals cargo.cod_cargo
                        where opcao.cod_concurso == cod_concurso
                        select new { cod_cargo = cargo.cod_cargo, descricao_cargo = cargo.descricao }).Distinct();
            return query;

        }
        /// <summary>
        /// Retorna as opções do concurso e suas informações
        /// </summary>
        /// <param name="cod_concurso"></param>
        /// <returns></returns>
        public IQueryable GetOpcoesDoConcurso(int cod_concurso)
        {
            entidades context = new Contexto().GetContexto();

            var query = (from opcao in context.tb_opcao
                         join cargo in context.tb_cargo
                         on opcao.cod_cargo equals cargo.cod_cargo
                         join nivel in context.tb_nivel_escolaridade
                         on cargo.cod_nivel equals nivel.cod_nivel
                         join cidade in context.tb_municipio
                         on opcao.cod_cidade equals cidade.cod_municipio
                         where opcao.cod_concurso == cod_concurso
                         select new
                         {
                             cod_opcao = opcao.cod_opcao,
                             cargo = cargo.descricao,
                             cod_identificador = opcao.codigo_identificador,
                             cidade = cidade.nome_cidade,
                             nivel = nivel.descricao_nivel,
                             vagas = opcao.vagas
                         }).OrderByDescending(o => o.cod_identificador);
          
            return query;

        }
        


        

        public IQueryable GetCidadesDoCargo(int cod_cargo,int cod_concurso)
        {
            entidades context = new Contexto().GetContexto();
            var query = from opcao in context.tb_opcao
                        join cidade in context.tb_municipio 
                        on opcao.cod_cidade equals cidade.cod_municipio
                        where opcao.cod_cargo == cod_cargo && opcao.cod_concurso == cod_concurso
                        select new {cod_cidade=cidade.cod_municipio, nome_cidade = cidade.nome_cidade };
            return query;

        }
    }
}
