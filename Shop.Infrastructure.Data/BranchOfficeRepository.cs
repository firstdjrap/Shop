using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly OrderContext orderContext;

        public BranchOfficeRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(BranchOffice branchOffice)
        {
            orderContext.BranchOffices.Add(branchOffice);
        }

        public void Del(int id)
        {
            BranchOffice branchOffice = orderContext.BranchOffices.Find(id);
            if (branchOffice != null)
                orderContext.BranchOffices.Remove(branchOffice);
        }

        public void Edit(BranchOffice branchOffice)
        {
            orderContext.Entry(branchOffice).State = EntityState.Modified;
        }

        public BranchOffice Get(int id)
        {
            return orderContext.BranchOffices.Find(id);
        }

        public IEnumerable<BranchOffice> GetList()
        {
            return orderContext.BranchOffices.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}