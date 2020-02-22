using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IQueryable<Promotion> _query;

        public PromotionRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
            _query = _shopContext.Promotions
                .Include(s => s.Products);
        }
        
        public async Task<Promotion> GetAsync(int id)
        {
            return await _query.SingleOrDefaultAsync(x => x.Id == id);
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
            return await _query.ToListAsync();
        }
    }
}