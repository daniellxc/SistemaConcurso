using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class MunicipioBO
    {
        #region DAO

        MunicipioDAO _DAO = GenericSingleton<MunicipioDAO>.GetInstance();

        public void Salvar(tb_municipio _municipio)
        {
            try
            {
                _DAO.Add(_municipio);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar municipio." + ex.Message);
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
                throw new Exception("Erro ao atualizar municipio." + e.Message);
            }
        }

        public void Deletar(tb_municipio _municipio)
        {
            try
            {
                _municipio = _DAO.Find(m => m.cod_municipio == _municipio.cod_municipio).First<tb_municipio>();
                _DAO.Delete(_municipio);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir o municipio." + ex.Message);
            }
        }

        public IQueryable<tb_municipio> Find(System.Linq.Expressions.Expression<Func<tb_municipio, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_municipio> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
