using Business.Servies.Abstract;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    public class CampainService : ICampainService
    {
        private readonly ICampainRepository _campainRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CampainService(ICampainRepository campainRepository, IUnitOfWork unitOfWork)
        {
            _campainRepository = campainRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Campaing?> GetAsync(Expression<Func<Campaing, bool>> predicate)
        {
            Campaing? campain = await _campainRepository.GetAsync(predicate);
            return campain;
        }

        public async Task<List<Campaing>?> GetListAsync(Expression<Func<Campaing, bool>>? predicate = null)
        {
            IEnumerable<Campaing> campaings = await _campainRepository.GetListAsync(predicate);
            return campaings.ToList();
        }

        public Campaing Add(Campaing campaing)
        {
            Campaing addedCampaing = _campainRepository.Add(campaing);
            _unitOfWork.SaveChanges();
            return addedCampaing;
        }

        public Campaing Delete(Campaing campaing)
        {
            campaing.IsDeleted = true;
            _campainRepository.Update(campaing);
            _unitOfWork.SaveChanges();
            return campaing;
        }



        public Campaing Update(Campaing campaing)
        {
            Campaing updatedCampain = _campainRepository.Update(campaing);
            _unitOfWork.SaveChanges();
            return updatedCampain;
        }
        public async Task<List<int>> GetAvailableInstallments(decimal totalAmount)
        {
            var availableInstallments = await _campainRepository.Query().Where(c => totalAmount >= c.MinAmount && totalAmount <= c.MaxAmount)
                .Select(c => c.Installment)
                .ToListAsync();
            availableInstallments.Insert(0, 0);

            return availableInstallments;
        }
    }
}
