using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;
using System.Collections.Generic;

namespace Shop.Infrastructure.Business
{
    public class ProductShop : IProduct
    {
        private readonly IProductRepository _productRepository;

        public ProductShop(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
            _productRepository.Save();
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }

        public void Edit(Product product)
        {
            var baseProduct = _productRepository.GetById(product.Id);
            baseProduct.Name = product.Name;
            baseProduct.Price = product.Price;
            baseProduct.BranchOfficeId = product.BranchOfficeId;
            baseProduct.StorageId = product.StorageId;

            _productRepository.Edit(baseProduct);
            _productRepository.Save();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetList()
        {
            return _productRepository.GetList();
        }
    }
}