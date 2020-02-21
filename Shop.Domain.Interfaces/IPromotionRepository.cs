using Shop.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces
{
    public interface IPromotionRepository:IRepository<Promotion, int>
    {
        Task<Promotion> AddAsync(Promotion promotion);
        Task<Promotion> UpdateAsync(Promotion promotion);
        Task<IEnumerable<Promotion>> GetAsync();
    }
}