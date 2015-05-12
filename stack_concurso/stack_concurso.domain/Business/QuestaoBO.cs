using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
   public  class QuestaoBO
    {
        #region DAO

       QuestaoDAO _DAO = GenericSingleton<QuestaoDAO>.GetInstance();

       public void Salvar(tb_questao _questao)
        {
            try
            {
                _DAO.Add(_questao);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar questao." + ex.Message);
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
                throw new Exception("Erro ao atualizar questao." + e.Message);
            }
        }

        public void Deletar(tb_questao _questao)
        {
            try
            {
                _questao = _DAO.Find(q => q.cod_questao == _questao.cod_questao).First<tb_questao>();
                _DAO.Delete(_questao);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir questao." + ex.Message);
            }
        }

        public IQueryable<tb_questao> Find(System.Linq.Expressions.Expression<Func<tb_questao, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_questao> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion

        public  tb_questao getQuestao(int cod_questao)
        {
            try
            {
                return Find(q => q.cod_questao == cod_questao).First<tb_questao>();
            }
            catch
            {
                return null;
            }
        }
    }
}
