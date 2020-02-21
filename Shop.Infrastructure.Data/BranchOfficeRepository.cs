using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly ShopContext shopContext;

        public BranchOfficeRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(BranchOffice branchOffice)
        {
            shopContext.BranchOffices.Add(branchOffice);
        }

        public void Delete(int id)
        {
            BranchOffice branchOffice = shopContext.BranchOffices.Find(id);
            if (branchOffice != null)
                shopContext.BranchOffices.Remove(branchOffice);
        }

        public void Edit(BranchOffice branchOffice)
        {
            shopContext.Entry(branchOffice).State = EntityState.Modified;
        }

        public BranchOffice Get(int id)
        {
            return shopContext.BranchOffices.Find(id);
        }

        public IEnumerable<BranchOffice> GetList()
        {
            return shopContext.BranchOffices.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}