using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IDiscountCardRepository
    {
        void Add(DiscountCard product);
        void Del(int id);
        void Edit(DiscountCard product);
        DiscountCard Get(int id);
        IEnumerable<DiscountCard> GetList();
        void Save();
    }
}