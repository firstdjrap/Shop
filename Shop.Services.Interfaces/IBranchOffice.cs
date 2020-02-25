using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Services.Interfaces
{
    public interface IBranchOffice
    {
        void Add(BranchOffice branchOffice);
        void Delete(int id);
        void Edit(BranchOffice branchOffice);
        BranchOffice Get(int id);
        IEnumerable<BranchOffice> GetList();
    }
}