using Business.Servies.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Org.BouncyCastle.Bcpg;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order?> GetAsync(Expression<Func<Order, bool>> predicate)
        {
            Order? order = await _orderRepository.GetAsync(predicate);
            return order;
        }

        public async Task<List<Order>?> GetListAsync(Expression<Func<Order, bool>>? predicate = null)
        {
            IEnumerable<Order> orders = await _orderRepository.GetListAsync(predicate);
            return orders.ToList();
        }

        public Order Add(Order order)
        {
            Order addedorder = _orderRepository.Add(order);
            return addedorder;
        }

        public Order Delete(Order order)
        {
            _orderRepository.Delete(order);
            return order;
        }



        public Order Update(Order order)
        {
            Order updatedorder = _orderRepository.Update(order);
            return updatedorder;
        }
    }
}
