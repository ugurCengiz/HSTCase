using Business.Servies.Abstract;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using Org.BouncyCastle.Bcpg;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
  public  class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Order?> GetAsync(Expression<Func<Order, bool>> predicate, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null)
        {
            Order? order = await _orderRepository.GetAsync(predicate,include);
            return order;
        }

        public async Task<List<Order>?> GetListAsync(Expression<Func<Order, bool>>? predicate = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null)
        {
            IEnumerable<Order> orders = await _orderRepository.GetListAsync(predicate,include);
            return orders.ToList();
        }

        public Order Add(Order order)
        {
            try
            {
                Order addedorder = _orderRepository.Add(order);
                _unitOfWork.SaveChanges();
                return addedorder;
            }
            catch (Exception e)
            {

                throw;
            }
        
        }

        public Order Delete(Order order)
        {
            _orderRepository.Delete(order);
            _unitOfWork.SaveChanges();
            return order;
        }



        public Order Update(Order order)
        {
            Order updatedorder = _orderRepository.Update(order);
            _unitOfWork.SaveChanges();
            return updatedorder;
        }
    }
}
