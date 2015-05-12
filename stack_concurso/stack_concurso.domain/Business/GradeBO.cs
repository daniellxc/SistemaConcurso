using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
   public  class GradeBO
    {
        #region DAO

        GradeDAO _DAO = GenericSingleton<GradeDAO>.GetInstance();

        public void Salvar(tb_grade _grade)
        {
            try
            {
                _DAO.Add(_grade);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar grade." + ex.Message);
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
                throw new Exception("Erro ao atualizar grade." + e.Message);
            }
        }

        public void Deletar(tb_grade _grade)
        {
            try
            {
                _grade = _DAO.Find(g => g.cod_grade == _grade.cod_grade).First<tb_grade>();
                _DAO.Delete(_grade);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir grade." + ex.Message);
            }
        }

        public IQueryable<tb_grade> Find(System.Linq.Expressions.Expression<Func<tb_grade, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_grade> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
