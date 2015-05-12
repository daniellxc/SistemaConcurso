using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class CargoBO
    {
        #region DAO

        CargoDAO _DAO = GenericSingleton<CargoDAO>.GetInstance();

        public void Salvar(tb_cargo _cargo)
        {
            try
            {
                _DAO.Add(_cargo);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar cargo." + ex.Message);
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
                throw new Exception("Erro ao atualizar cargo." + e.Message);
            }
        }

        public void Deletar(tb_cargo _cargo)
        {
            try
            {
                _cargo = _DAO.Find(c => c.cod_cargo == _cargo.cod_cargo).First<tb_cargo>();
                _DAO.Delete(_cargo);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir o cargo." + ex.Message);
            }
        }

        public IQueryable<tb_cargo> Find(System.Linq.Expressions.Expression<Func<tb_cargo, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_cargo> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion


       
    }
}
