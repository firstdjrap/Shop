using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Services.Interfaces
{
    public interface IDiscountCard
    {
        void Add(DiscountCard discountCard);
        void Delete(int id);
        void Edit(DiscountCard discountCard);
        DiscountCard GetById(int id);
        DiscountCard GetByNumber(string number);
        IEnumerable<DiscountCard> GetList();
    }
}