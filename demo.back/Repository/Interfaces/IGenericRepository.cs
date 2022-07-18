using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        T? FindById(int id);
        Task<IList<T>> FindAllAsync();
        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        void DeleteById(int id);
    }
}
