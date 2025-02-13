using Business.Servies.Abstract;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BasketManager(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Basket?> GetAsync(Expression<Func<Basket, bool>> predicate, Func<IQueryable<Basket>, IIncludableQueryable<Basket, object>>? include = null)
        {
            Basket? basket = await _basketRepository.GetAsync(predicate, include);
            return basket;
        }

        public async Task<List<Basket>?> GetListAsync(Expression<Func<Basket, bool>>? predicate = null, Func<IQueryable<Basket>, IIncludableQueryable<Basket, object>>? include = null)
        {
            IEnumerable<Basket> baskets = await _basketRepository.GetListAsync(predicate, include);
            return baskets.ToList();
        }
        public Basket Add(Basket basket)
        {
            Basket addedBasket = _basketRepository.Add(basket);
            _unitOfWork.SaveChanges();
            return addedBasket;
        }

        public Basket Delete(Basket basket)
        {
            _basketRepository.Delete(basket);
            _unitOfWork.SaveChanges();
            return basket;
        }

        public Basket Update(Basket basket)
        {
            Basket updatedBasket = _basketRepository.Update(basket);
            _unitOfWork.SaveChanges();
            return updatedBasket;

        }
    }
}
