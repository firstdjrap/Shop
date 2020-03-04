using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;
using System.Collections.Generic;

namespace Shop.Infrastructure.Business
{
    public class BranchOfficeShop : IBranchOffice
    {
        private readonly IBranchOfficeRepository _branchOfficeRepository;

        public BranchOfficeShop(IBranchOfficeRepository branchOfficeRepository)
        {
            _branchOfficeRepository = branchOfficeRepository;
        }

        public void Add(BranchOffice branchOffice)
        {
            _branchOfficeRepository.Add(branchOffice);
            _branchOfficeRepository.Save();
        }

        public void Delete(int id)
        {
            _branchOfficeRepository.Delete(id);
            _branchOfficeRepository.Save();
        }

        public void Edit(BranchOffice branchOffice)
        {
            var baseBranchOffice = _branchOfficeRepository.GetById(branchOffice.Id);
            baseBranchOffice.Name = branchOffice.Name;
            baseBranchOffice.Address = branchOffice.Address;
            baseBranchOffice.PhoneNumber = branchOffice.PhoneNumber;

            _branchOfficeRepository.Edit(baseBranchOffice);
            _branchOfficeRepository.Save();
        }

        public BranchOffice GetById(int id)
        {
            return _branchOfficeRepository.GetById(id);
        }

        public IEnumerable<BranchOffice> GetList()
        {
            return _branchOfficeRepository.GetList();
        }
    }
}