using System.Linq.Expressions;
using Tailor_Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity:BaseEnity<Tkey>
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? fillter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        TEntity GetById(Tkey id);
        void Insert(TEntity entity);
        void Delete(Tkey id);
        void Delete(TEntity entity);
        void Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? fillter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        Task<TEntity> GetByIdAsync(Tkey id);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync(Tkey id);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
