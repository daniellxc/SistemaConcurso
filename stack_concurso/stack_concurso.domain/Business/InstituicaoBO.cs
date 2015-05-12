using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class InstituicaoBO
    {
        #region DAO

        InstituicaoDAO _DAO = GenericSingleton<InstituicaoDAO>.GetInstance();

        public void Salvar(tb_instituicao _instituicao)
        {
            try
            {
                _DAO.Add(_instituicao);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar instituição." + ex.Message);
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
                throw new Exception("Erro ao atualizar instituição." + e.Message);
            }
        }

        public void Deletar(tb_instituicao _instituicao)
        {
            try
            {
                _instituicao = _DAO.Find(i => i.cod_instituicao == _instituicao.cod_instituicao).First<tb_instituicao>();
                _DAO.Delete(_instituicao);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir instituição." + ex.Message);
            }
        }

        public IQueryable<tb_instituicao> Find(System.Linq.Expressions.Expression<Func<tb_instituicao, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_instituicao> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
