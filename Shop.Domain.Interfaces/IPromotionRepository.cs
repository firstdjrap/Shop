using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IPromotionRepository
    {
        void Add(Promotion product);
        void Delete(int id);
        void Edit(Promotion product);
        Promotion Get(int id);
        IEnumerable<Promotion> GetList();
        void Save();
    }
}