using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRespository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _todoContext;
        private readonly DbSet<T> _entity;

        public GenericRespository(TodoContext todoContext)
        {
            _todoContext = todoContext;
            _entity = _todoContext.Set<T>();
        }

        public void Add(T entity)
        {
            _entity.Add(entity);
            _todoContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = FindById(id);

            if (entity == null) return;

            _entity.Remove(entity);
            _todoContext.SaveChanges();
        }

        public async Task<IList<T>> FindAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entity.Where(predicate).ToListAsync();
        }

        public T? FindById(int id)
        {
            return _entity.SingleOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _todoContext.SaveChanges();
        }
    }
}
