using System.Linq.Expressions;

namespace stepmedia_demo.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> FindByIdAsync(object id);
        TEntity FindById(object id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
