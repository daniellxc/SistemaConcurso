using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
   public class CarteiraBO
    {
        #region DAO

        CarteiraDAO _DAO = GenericSingleton<CarteiraDAO>.GetInstance();

        public void Salvar(tb_carteira _carteira)
        {
            try
            {
                _DAO.Add(_carteira);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar carteira." + ex.Message);
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
                throw new Exception("Erro ao atualizar carteira." + e.Message);
            }
        }

        public void Deletar(tb_carteira _carteira)
        {
            try
            {
                _carteira = _DAO.Find(c => c.cod_carteira == _carteira.cod_carteira).First<tb_carteira>();
                _DAO.Delete(_carteira);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir a carteira." + ex.Message);
            }
        }

        public IQueryable<tb_carteira> Find(System.Linq.Expressions.Expression<Func<tb_carteira, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_carteira> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
