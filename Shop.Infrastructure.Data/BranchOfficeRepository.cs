using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly OrderContext _orderContext;

        public BranchOfficeRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(BranchOffice branchOffice)
        {
            _orderContext.BranchOffices.Add(branchOffice);
        }

        public void Del(int id)
        {
            BranchOffice branchOffice = _orderContext.BranchOffices.Find(id);
            if (branchOffice != null)
                _orderContext.BranchOffices.Remove(branchOffice);
        }

        public void Edit(BranchOffice branchOffice)
        {
            _orderContext.Entry(branchOffice).State = EntityState.Modified;
        }

        public BranchOffice Get(int id)
        {
            return _orderContext.BranchOffices.Find(id);
        }

        public IEnumerable<BranchOffice> GetList()
        {
            return _orderContext.BranchOffices.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}