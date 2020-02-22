using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IPromotionRepository
    {
        void Add(Promotion promotion);
        void Delete(int id);
        void Edit(Promotion promotion);
        Promotion GetById(int id);
        IEnumerable<Promotion> GetList();
        void Save();
    }
}