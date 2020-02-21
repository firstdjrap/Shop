using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IBranchOfficeRepository
    {
        void Add(BranchOffice product);
        void Delete(int id);
        void Edit(BranchOffice product);
        BranchOffice Get(int id);
        IEnumerable<BranchOffice> GetList();
        void Save();
    }
}