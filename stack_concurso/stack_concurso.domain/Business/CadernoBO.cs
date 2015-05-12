using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
   public class CadernoBO
    {
        #region DAO

       CadernoDAO _DAO = GenericSingleton<CadernoDAO>.GetInstance();

        public void Salvar(tb_caderno _caderno)
        {
            try
            {
                _DAO.Add(_caderno);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar caderno." + ex.Message);
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
                throw new Exception("Erro ao atualizar caderno." + e.Message);
            }
        }

        public void Deletar(tb_caderno _caderno)
        {
            try
            {
                _caderno = _DAO.Find(cd => cd.cod_caderno == _caderno.cod_caderno).First<tb_caderno>();
                _DAO.Delete(_caderno);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir o caderno." + ex.Message);
            }
        }

        public IQueryable<tb_caderno> Find(System.Linq.Expressions.Expression<Func<tb_caderno, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_caderno> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion

        public List<tb_questao_caderno> get_questoes_caderno(string num_inscricao)
        {
            entidades context = new Contexto().GetContexto();

            var query = from candidato in context.tb_candidato
                        join opcao in context.tb_opcao
                        on candidato.cod_opcao equals opcao.cod_opcao
                        join prova in context.tb_prova
                        on opcao.cod_opcao equals prova.cod_opcao
                        join questao in context.tb_questao
                        on prova.cod_prova equals questao.cod_prova
                        join caderno in context.tb_caderno
                        on prova.cod_opcao equals caderno.cod_opcao
                        join questao_caderno in context.tb_questao_caderno
                        on caderno.cod_caderno equals questao_caderno.cod_caderno
                        where candidato.num_inscricao == num_inscricao && questao_caderno.cod_questao == questao.cod_questao
                        select questao_caderno;
            return query.ToList<tb_questao_caderno>();
        }
    }
}
