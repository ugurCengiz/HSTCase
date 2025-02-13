using Business.Servies.Abstract;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProductManager(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            Product? product = await _productRepository.GetAsync(predicate);
            return product;
        }

        public async Task<List<Product>?> GetListAsync(Expression<Func<Product, bool>>? predicate = null)
        {
            IEnumerable<Product> products = await _productRepository.GetListAsync(predicate);
            return products.ToList();
        }

        public Product Add(Product product)
        {
            Product added = _productRepository.Add(product);
            _unitOfWork.SaveChanges();
            return added;
        }

        public Product Delete(Product product)
        {
            product.IsDeleted = true;
            _productRepository.Update(product);
            _unitOfWork.SaveChanges();
            return product;
        }



        public Product Update(Product product)
        {


            Product updated = _productRepository.Update(product);
            _unitOfWork.SaveChanges();
            return updated;
        }
    }
}
