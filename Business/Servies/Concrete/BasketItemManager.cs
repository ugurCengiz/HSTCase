using Business.Servies.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Org.BouncyCastle.Bcpg;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    class BasketItemManager : IBasketItemService
    {
        private readonly BasketItemRepository _basketItemRepository;

        public BasketItemManager(BasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }

        public async Task<BasketItem?> GetAsync(Expression<Func<BasketItem, bool>> predicate)
        {
            BasketItem basketItem = await _basketItemRepository.GetAsync(predicate);
            return basketItem;
        }

        public async Task<List<BasketItem>?> GetListAsync(Expression<Func<BasketItem, bool>>? predicate = null)
        {
            IEnumerable<BasketItem> baskeItems = await _basketItemRepository.GetListAsync(predicate);
            return baskeItems.ToList();
        }
        public BasketItem Add(BasketItem basketItem)
        {
            BasketItem addedBasketItem = _basketItemRepository.Add(basketItem);
            return addedBasketItem;
        }

        public BasketItem Delete(BasketItem basketItem)
        {
            _basketItemRepository.Delete(basketItem);
            return basketItem;
        }



        public BasketItem Update(BasketItem basketItem)
        {
            BasketItem updatedBasketItem = _basketItemRepository.Update(basketItem);
            return updatedBasketItem;
        }
    }
}
