using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly ShopContext _shopContext;

        public BranchOfficeRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(BranchOffice branchOffice)
        {
            _shopContext.BranchOffices.Add(branchOffice);
        }

        public void Delete(int id)
        {
            BranchOffice branchOffice = _shopContext.BranchOffices.Find(id);
            if (branchOffice != null)
                _shopContext.BranchOffices.Remove(branchOffice);
        }

        public void Edit(BranchOffice branchOffice)
        {
            _shopContext.Entry(branchOffice).State = EntityState.Modified;
        }

        public BranchOffice GetById(int id)
        {
            return _shopContext.BranchOffices.Find(id);
        }

        public IEnumerable<BranchOffice> GetList()
        {
            return _shopContext.BranchOffices.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}