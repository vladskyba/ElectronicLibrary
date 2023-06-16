using ElectronicLibrary.DAO.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ElectronicLibrary.DAO.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync(
                   Expression<Func<TEntity, bool>> filter = null,
                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> AddAsync(TEntity entity);
    }
}
