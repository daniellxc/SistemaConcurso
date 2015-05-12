using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Interfaces;
using stack_concurso.domain.Modelo;
using stack_concurso.domain.Acessorios;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data;

namespace stack_concurso.domain.Classes
{
   public abstract class AbstractCrudDAO<T>:IBaseCrudDAO<T> where T : class
    {
        entidades contexto = new Contexto().GetContexto();
       //entidades contexto = GenericSingleton<entidades>.GetInstance();

        #region BASE_DAO

        public void Add(T pEntity)
        {
            contexto.AddObject(pEntity.GetType().Name, pEntity);
        }

        public void Delete(T pEntity)
        {
            try
            {
                ObjectSet<T> _obj = contexto.CreateObjectSet<T>();
                // _obj.Attach(pEntity);
                contexto.ObjectStateManager.ChangeObjectState(pEntity, System.Data.EntityState.Deleted);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                contexto.Refresh(RefreshMode.StoreWins, pEntity);
                throw ex;
            }
            //try
            // {
            //     entidades.DeleteObject(pEntity);
            //     entidades.SaveChanges();
            // }
            // catch (OptimisticConcurrencyException)
            // {
            //     entidades.Refresh(RefreshMode.ClientWins, pEntity);
            //     entidades.SaveChanges();
            // }
        }

        public void Excluir(Expression<Func<T, bool>> expressao, T pEntity)
        {
            try
            {
                ObjectSet<T> _obj = contexto.CreateObjectSet<T>();

                T objexcluir = _obj.Where(expressao).FirstOrDefault();
                if (objexcluir != null)
                {
                    contexto.DeleteObject(objexcluir);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                contexto.Refresh(RefreshMode.ClientWins, pEntity);
            }
        }

        public void Update(T pEntity)
        {
            contexto.AttachTo(pEntity.GetType().Name, pEntity);
            contexto.ObjectStateManager.ChangeObjectState(pEntity, EntityState.Modified);
            try
            {
                contexto.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                contexto.Refresh(RefreshMode.ClientWins, pEntity);
                contexto.SaveChanges();
            }

        }



        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return contexto.CreateObjectSet<T>().Where(where);
        }

        public IQueryable<T> GetAll()
        {
            return contexto.CreateObjectSet<T>();
        }

        public void SaveChanges()
        {
            contexto.SaveChanges();
        }

        public void ExecuteComand(string command)
        {
            contexto.ExecuteStoreCommand(command);
        }


        #endregion

    }
}
