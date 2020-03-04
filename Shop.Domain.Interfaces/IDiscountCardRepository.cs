using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IDiscountCardRepository
    {
        void Add(DiscountCard discountCard);
        void Delete(int id);
        void Edit(DiscountCard discountCard);
        DiscountCard GetById(int id);
        DiscountCard GetByNumber(string number);
        IEnumerable<DiscountCard> GetList();
        void Save();
    }
}