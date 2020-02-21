using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ShopContext _shopContext;

        public PromotionRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }
        
        public async Task<Promotion> GetAsync(int id)
        {
            return await _shopContext.Promotions.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Promotion> AddAsync(Promotion promotion)
        {
            _shopContext.Promotions.Add(promotion);
            await _shopContext.SaveChangesAsync();

            return promotion;
        }

        public async Task<Promotion> UpdateAsync(Promotion promotion)
        {
            _shopContext.Promotions.Update(promotion);
            await _shopContext.SaveChangesAsync();

            return promotion;
        }

        public async Task<IEnumerable<Promotion>> GetAsync()
        {
            return await _shopContext.Promotions.ToListAsync();
        }
    }
}