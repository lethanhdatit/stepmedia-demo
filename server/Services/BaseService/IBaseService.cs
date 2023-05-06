using System.Linq.Expressions;

namespace stepmedia_demo.Services
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity dto);

        Task<TEntity> UpdateAsync(TEntity dto);

        Task DeleteAsync(object keyValues);

        Task<TEntity> FindByIdAsync(object keyValues);
        TEntity FindById(object keyValues);
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
