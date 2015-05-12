using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class DeficienciaBO
    {
        #region DAO

        DeficienciaDAO _DAO = GenericSingleton<DeficienciaDAO>.GetInstance();

        public void Salvar(tb_deficiencia _deficiencia)
        {
            try
            {
                _DAO.Add(_deficiencia);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar deficiencia." + ex.Message);
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
                throw new Exception("Erro ao atualizar deficiencia." + e.Message);
            }
        }

        public void Deletar(tb_deficiencia _deficiencia)
        {
            try
            {
                _deficiencia = _DAO.Find(d => d.cod_deficiencia == _deficiencia.cod_deficiencia).First<tb_deficiencia>();
                _DAO.Delete(_deficiencia);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir deficiencia." + ex.Message);
            }
        }

        public IQueryable<tb_deficiencia> Find(System.Linq.Expressions.Expression<Func<tb_deficiencia, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_deficiencia> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
