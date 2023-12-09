using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;
using Task = System.Threading.Tasks.Task;

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
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            TEntity entity = await _dbSet.FindAsync(id) ?? throw new Exception($"Has not found {nameof(entity)} has id ({id})");

            Delete(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            if(_context.Entry(entity).State==EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
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

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
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
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual TEntity GetById(TKey id)
        {
            return _dbSet.Find(id)??throw new Exception($"Has not found {nameof(TEntity)} has id ({id})");
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception($"Has not found {nameof(TEntity)} has id ({id})");
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteListAsync(List<TKey> ids)
        {
            List<TEntity> entitys = await _dbSet.Where(c=>ids.Contains(c.Id)).ToListAsync();

            _dbSet.RemoveRange(entitys);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteListAsync(List<TEntity> entitys)
        {
            entitys.ForEach(entity =>
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
            });
            _dbSet.RemoveRange(entitys);
            await _context.SaveChangesAsync();
        }
    }
}
