using System.Threading.Tasks;
using Shop.Domain.Core;

namespace Shop.Domain.Interfaces
{
    public interface IRepository<TEntity, TEntityId> where TEntity : IEntity<TEntityId>
    {
        Task<TEntity> GetAsync(TEntityId id);
    }
}