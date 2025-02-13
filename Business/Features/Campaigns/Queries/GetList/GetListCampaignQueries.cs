using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Campaigns.Queries.GetList
{
    public class GetListCampaignQueries : IRequest<List<Campaing>>
    {

        public class GetListCampaignQueriesHandler : IRequestHandler<GetListCampaignQueries, List<Campaing>>
        {
            private readonly ICampainService _campainService;

            public GetListCampaignQueriesHandler(ICampainService campainService)
            {
                _campainService = campainService;
            }

            public async Task<List<Campaing>> Handle(GetListCampaignQueries request, CancellationToken cancellationToken)
            {
                return await _campainService.GetListAsync(x=>!x.IsDeleted);


            }
        }
    }
}
