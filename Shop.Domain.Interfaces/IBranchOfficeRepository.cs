using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IBranchOfficeRepository
    {
        void Add(BranchOffice branchOffice);
        void Delete(int id);
        void Edit(BranchOffice branchOffice);
        BranchOffice GetById(int id);
        IEnumerable<BranchOffice> GetList();
        void Save();
    }
}