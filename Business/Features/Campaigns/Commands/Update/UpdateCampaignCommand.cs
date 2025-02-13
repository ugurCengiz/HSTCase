using Business.Mappings;
using Business.Servies.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using MediatR;
using System.Runtime.Serialization;

namespace Business.Features.Campaigns.Commands.Update
{
    public class UpdateCampaignCommand : IRequest<UpdateCampaignResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Installment { get; set; }
        public Status Status { get; set; }

        public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, UpdateCampaignResponse>
        {
            private readonly ICampainService _campainService;

            public UpdateCampaignCommandHandler(ICampainService campainService)
            {
                _campainService = campainService;
            }

            public async Task<UpdateCampaignResponse> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
            {
                Campaing campaing = await _campainService.GetAsync(x => x.Id == request.Id);

                campaing = ObjectMapper.Mapper.Map(request, campaing);

                _campainService.Update(campaing);

                UpdateCampaignResponse response = ObjectMapper.Mapper.Map<UpdateCampaignResponse>(campaing);
                return response;
            }
        }
    }
}
