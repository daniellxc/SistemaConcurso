using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Classes;
using stack_concurso.domain.Acessorios;
using stack_concurso.domain.Modelo;

namespace stack_concurso.domain.Business
{
    public class UsuarioBO
    {
        #region DAO

        UsuarioDAO _DAO = GenericSingleton<UsuarioDAO>.GetInstance();

        public void Salvar(tb_usuario _usuario)
        {
            try
            {
                _DAO.Add(_usuario);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar usuario." + ex.Message);
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
                throw new Exception("Erro ao atualizar usuario." + e.Message);
            }
        }

        public void Deletar(tb_usuario _usuario)
        {
            try
            {
                _usuario = _DAO.Find(u => u.cod_usuario == _usuario.cod_usuario).First<tb_usuario>();
                _DAO.Delete(_usuario);
                _DAO.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não possível excluir usuario." + ex.Message);
            }
        }

        public IQueryable<tb_usuario> Find(System.Linq.Expressions.Expression<Func<tb_usuario, bool>> where)
        {
            return _DAO.Find(where);
        }

        public IQueryable<tb_usuario> GetAll()
        {
            return _DAO.GetAll();
        }
        #endregion


        public tb_usuario GetUsuario(string login, string senha)
        {
            try
            {
                return Find(u => u.login == login && u.senha == senha).First<tb_usuario>();
            }
            catch
            {
                return null;
            }
        }

    }
}
