using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class SalaConcursoBO
    {
        #region DAO

        SalaConcursoDAO _DAO = GenericSingleton<SalaConcursoDAO>.GetInstance();

        public void Salvar(tb_sala_concurso _salaConcurso)
        {
            try
            {
                _DAO.Add(_salaConcurso);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar sala concurso." + ex.Message);
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
                throw new Exception("Erro ao atualizar sala concurso." + e.Message);
            }
        }

        public void Deletar(tb_sala_concurso _salaConcurso)
        {
            try
            {
                _salaConcurso = _DAO.Find(sc => sc.cod_sala_concurso == _salaConcurso.cod_sala_concurso).First<tb_sala_concurso>();
                _DAO.Delete(_salaConcurso);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir sala concurso." + ex.Message);
            }
        }

        public IQueryable<tb_sala_concurso> Find(System.Linq.Expressions.Expression<Func<tb_sala_concurso, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_sala_concurso> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
