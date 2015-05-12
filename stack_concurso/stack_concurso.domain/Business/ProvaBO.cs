using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
   public class ProvaBO
    {
        #region DAO

       ProvaDAO _DAO = GenericSingleton<ProvaDAO>.GetInstance();

        public void Salvar(tb_prova _prova)
        {
            try
            {
                _DAO.Add(_prova);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar prova." + ex.Message);
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
                throw new Exception("Erro ao atualizar prova." + e.Message);
            }
        }

        public void Deletar(tb_prova _prova)
        {
            try
            {
                _prova = _DAO.Find(p => p.cod_prova == _prova.cod_prova).First<tb_prova>();
                _DAO.Delete(_prova);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir prova." + ex.Message);
            }
        }

        public IQueryable<tb_prova> Find(System.Linq.Expressions.Expression<Func<tb_prova, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_prova> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
