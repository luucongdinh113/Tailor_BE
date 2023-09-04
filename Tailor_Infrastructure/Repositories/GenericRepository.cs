using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity :BaseEnity<TKey>
    {
        private readonly TaiLorContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(TaiLorContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void Delete(TKey id)
        {
            TEntity entity = _dbSet.Find(id) ?? throw new Exception($"Has not found {nameof(entity)} has id ({id})");

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if(_context.Entry(entity).State==EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(TKey id)
        {
            return _dbSet.Find(id)??throw new Exception($"Has not found {nameof(TEntity)} has id ({id})");
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
