using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class QuestaoCadernoBO
    {
        #region DAO

        QuestaoCadernoDAO _DAO = GenericSingleton<QuestaoCadernoDAO>.GetInstance();

        public void Salvar(tb_questao_caderno _questaoCaderno)
        {
            try
            {
                _DAO.Add(_questaoCaderno);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar questao caderno." + ex.Message);
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
                throw new Exception("Erro ao atualizar questao caderno." + e.Message);
            }
        }

        public void Deletar(tb_questao_caderno _questaoCaderno)
        {
            try
            {
                _questaoCaderno = _DAO.Find(qc => qc.cod_questao_caderno == _questaoCaderno.cod_questao_caderno).First<tb_questao_caderno>();
                _DAO.Delete(_questaoCaderno);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir o caderno." + ex.Message);
            }
        }

        public IQueryable<tb_questao_caderno> Find(System.Linq.Expressions.Expression<Func<tb_questao_caderno, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_questao_caderno> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
