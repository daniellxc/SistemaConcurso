using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class LocalProvaBO
    {
        #region DAO

        LocalProvaDAO _DAO = GenericSingleton<LocalProvaDAO>.GetInstance();

        public void Salvar(tb_local_prova _localProva)
        {
            try
            {
                _DAO.Add(_localProva);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar local prova." + ex.Message);
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
                throw new Exception("Erro ao atualizar local prova." + e.Message);
            }
        }

        public void Deletar(tb_local_prova _localProva)
        {
            try
            {
                _localProva = _DAO.Find(lp => lp.cod_local == _localProva.cod_local).First<tb_local_prova>();
                _DAO.Delete(_localProva);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir local prova." + ex.Message);
            }
        }

        public IQueryable<tb_local_prova> Find(System.Linq.Expressions.Expression<Func<tb_local_prova, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_local_prova> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
