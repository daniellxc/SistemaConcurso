using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class RespostaBO
    {
        #region DAO

        RespostaDAO _DAO = GenericSingleton<RespostaDAO>.GetInstance();

        public void Salvar(tb_resposta _resposta)
        {
            try
            {
                _DAO.Add(_resposta);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar resposta." + ex.Message);
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
                throw new Exception("Erro ao atualizar resposta." + e.Message);
            }
        }

        public void Deletar(tb_resposta _resposta)
        {
            try
            {
                _resposta = _DAO.Find(r => r.cod_resposta == _resposta.cod_resposta).First<tb_resposta>();
                _DAO.Delete(_resposta);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir resposta." + ex.Message);
            }
        }

        public IQueryable<tb_resposta> Find(System.Linq.Expressions.Expression<Func<tb_resposta, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_resposta> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
