using Business.Servies.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailManager(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail?> GetAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            OrderDetail? orderDetail = await _orderDetailRepository.GetAsync(predicate);
            return orderDetail;
        }

        public async Task<List<OrderDetail>?> GetListAsync(Expression<Func<OrderDetail, bool>>? predicate = null)
        {
            IEnumerable<OrderDetail> orderDetails = await _orderDetailRepository.GetListAsync(predicate);
            return orderDetails.ToList();
        }
        public OrderDetail Add(OrderDetail orderDetail)
        {
            OrderDetail addedorder = _orderDetailRepository.Add(orderDetail);
            return addedorder;
        }

        public OrderDetail Delete(OrderDetail orderDetail)
        {
            _orderDetailRepository.Delete(orderDetail);
            return orderDetail;
        }



        public OrderDetail Update(OrderDetail orderDetail)
        {
            OrderDetail updatedorder = _orderDetailRepository.Update(orderDetail);
            return updatedorder;
        }
    }
}
