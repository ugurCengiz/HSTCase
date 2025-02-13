using Business.Mappings;
using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Campaigns.Commands.Delete
{
    public class DeleteCampaignCommand : IRequest<DeleteCampaignResponse>
    {
        public int Id { get; set; }

        public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, DeleteCampaignResponse>
        {
            private readonly ICampainService _campainService;

            public DeleteCampaignCommandHandler(ICampainService campainService)
            {
                _campainService = campainService;
            }

            public async Task<DeleteCampaignResponse> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
            {
                Campaing campaing = await _campainService.GetAsync(x => x.Id == request.Id);
                _campainService.Delete(campaing);
                DeleteCampaignResponse response = ObjectMapper.Mapper.Map<DeleteCampaignResponse>(campaing);
                return response;
            }
        }
    }
}
