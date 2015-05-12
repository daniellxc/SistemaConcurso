using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class UfBO
    {
        #region DAO

        UfDAO _DAO = GenericSingleton<UfDAO>.GetInstance();

        public void Salvar(tb_uf _uf)
        {
            try
            {
                _DAO.Add(_uf);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar uf." + ex.Message);
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
                throw new Exception("Erro ao atualizar uf." + e.Message);
            }
        }

        public void Deletar(tb_uf _uf)
        {
            try
            {
                _uf = _DAO.Find(uf => uf.cod_uf == _uf.cod_uf).First<tb_uf>();
                _DAO.Delete(_uf);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir uf." + ex.Message);
            }
        }

        public IQueryable<tb_uf> Find(System.Linq.Expressions.Expression<Func<tb_uf, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_uf> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
