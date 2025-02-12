using Business.Servies.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Org.BouncyCastle.Bcpg;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
    class CampainManager : ICampainService
    {
        private readonly ICampainRepository _campainRepository;

        public CampainManager(ICampainRepository campainRepository)
        {
            _campainRepository = campainRepository;
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
            return addedCampaing;
        }

        public Campaing Delete(Campaing campaing)
        {
            _campainRepository.Delete(campaing);
            return campaing;
        }



        public Campaing Update(Campaing campaing)
        {
            Campaing updatedCampain = _campainRepository.Update(campaing);
            return updatedCampain;
        }
    }
}
