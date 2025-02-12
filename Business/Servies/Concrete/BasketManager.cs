using Business.Servies.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketManager(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<Basket?> GetAsync(Expression<Func<Basket, bool>> predicate)
        {
            Basket? basket = await _basketRepository.GetAsync(predicate);
            return basket;
        }

        public async Task<List<Basket>?> GetListAsync(Expression<Func<Basket, bool>>? predicate = null)
        {
            IEnumerable<Basket> baskets = await _basketRepository.GetListAsync(predicate);
            return baskets.ToList();
        }
        public Basket Add(Basket basket)
        {
            Basket addedBasket = _basketRepository.Add(basket);
            return addedBasket;
        }

        public Basket Delete(Basket basket)
        {
            _basketRepository.Delete(basket);
            return basket;
        }

        public Basket Update(Basket basket)
        {
            Basket updatedBasket = _basketRepository.Update(basket);
            return updatedBasket;

        }
    }
}
