using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;
using System.Collections.Generic;

namespace Shop.Infrastructure.Business
{
    public class DiscountCardShop : IDiscountCard
    {
        private readonly IDiscountCardRepository _discountCardRepository;

        public DiscountCardShop(IDiscountCardRepository discountCardRepository)
        {
            _discountCardRepository = discountCardRepository;
        }

        public void Add(DiscountCard discountCard)
        {
            _discountCardRepository.Add(discountCard);
            _discountCardRepository.Save();
        }

        public void Delete(int id)
        {
            _discountCardRepository.Delete(id);
            _discountCardRepository.Save();
        }

        public void Edit(DiscountCard discountCard)
        {
            var baseDiscountCard = _discountCardRepository.GetById(discountCard.Id);
            baseDiscountCard.Number = discountCard.Number;
            baseDiscountCard.Percent = discountCard.Percent;
            baseDiscountCard.LifeTime = discountCard.LifeTime;

            _discountCardRepository.Edit(baseDiscountCard);
            _discountCardRepository.Save();
        }

        public DiscountCard GetById(int id)
        {
            return _discountCardRepository.GetById(id);
        }

        public DiscountCard GetByNumber(string number)
        {
            return _discountCardRepository.GetByNumber(number);
        }

        public IEnumerable<DiscountCard> GetList()
        {
            return _discountCardRepository.GetList();
        }
    }
}