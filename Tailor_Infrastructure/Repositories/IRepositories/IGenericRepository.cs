using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity:BaseEnity<Tkey>
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> fillter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetById(Tkey id);
        void Insert(TEntity entity);
        void Delete(Tkey id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
