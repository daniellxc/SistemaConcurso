using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class NivelEscolaridadeBO
    {
        #region DAO

        NivelEscolaridadeDAO _DAO = GenericSingleton<NivelEscolaridadeDAO>.GetInstance();

        public void Salvar(tb_nivel_escolaridade _ne)
        {
            try
            {
                _DAO.Add(_ne);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar nível escolaridade." + ex.Message);
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
                throw new Exception("Erro ao atualizar nível escolaridade." + e.Message);
            }
        }

        public void Deletar(tb_nivel_escolaridade _ne)
        {
            try
            {
                _ne = _DAO.Find(ne => ne.cod_nivel == _ne.cod_nivel).First<tb_nivel_escolaridade>();
                _DAO.Delete(_ne);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir nível escolaridade." + ex.Message);
            }
        }

        public IQueryable<tb_nivel_escolaridade> Find(System.Linq.Expressions.Expression<Func<tb_nivel_escolaridade, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_nivel_escolaridade> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion
    }
}
