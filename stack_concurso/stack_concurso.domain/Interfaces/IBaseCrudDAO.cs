using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace stack_concurso.domain.Interfaces
{
    interface IBaseCrudDAO<T>
    {
        void Add(T pEntity);    //Persiste uma entidade
        void Delete(T pEntity); //Deleta uma entidade
        void Update(T pEntity); //Atualiza uma entidade
        IQueryable<T> Find(Expression<Func<T, bool>> where); //Busca uma entidade passando uma expressão lambda
        IQueryable<T> GetAll(); //Retorna todas as ocorrências de uma entidade
        void SaveChanges(); //Salva alterações, já que o Entity Framework não é AutoCommited
    }
}
