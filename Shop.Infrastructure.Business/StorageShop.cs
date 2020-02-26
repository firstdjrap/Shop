using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;
using System.Collections.Generic;

namespace Shop.Infrastructure.Business
{
    public class StorageShop : IStorage
    {
        private readonly IStorageRepository _storageRepository;

        public StorageShop(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public void Add(Storage storage)
        {
            _storageRepository.Add(storage);
            _storageRepository.Save();
        }

        public void Delete(int id)
        {
            _storageRepository.Delete(id);
            _storageRepository.Save();
        }

        public void Edit(Storage storage)
        {
            var baseStorage = _storageRepository.GetById(storage.Id);
            baseStorage.Name = storage.Name;
            baseStorage.Address = storage.Address;
            baseStorage.PhoneNumber = storage.PhoneNumber;

            _storageRepository.Edit(baseStorage);
            _storageRepository.Save();
        }

        public Storage Get(int id)
        {
            return _storageRepository.GetById(id);
        }

        public IEnumerable<Storage> GetList()
        {
            return _storageRepository.GetList();
        }
    }
}