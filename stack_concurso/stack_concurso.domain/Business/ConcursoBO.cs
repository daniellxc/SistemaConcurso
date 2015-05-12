using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class ConcursoBO
    {
        #region DAO

        ConcursoDAO _DAO = GenericSingleton<ConcursoDAO>.GetInstance();

        public void Salvar(tb_concurso _concurso)
        {
            try
            {
                _DAO.Add(_concurso);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar concurso." + ex.Message);
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
                throw new Exception("Erro ao atualizar concurso." + e.Message);
            }
        }

        public void Deletar(tb_concurso _concurso)
        {
            try
            {
                _concurso = _DAO.Find(c => c.cod_concurso == _concurso.cod_concurso).First<tb_concurso>();
                _DAO.Delete(_concurso);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir o concurso." + ex.Message);
            }
        }

        public IQueryable<tb_concurso> Find(System.Linq.Expressions.Expression<Func<tb_concurso, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_concurso> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
