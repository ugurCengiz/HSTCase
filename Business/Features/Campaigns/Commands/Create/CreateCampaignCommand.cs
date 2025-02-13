using Business.Features.Products.Commands.Create;
using Business.Mappings;
using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Campaigns.Commands.Create
{
    public class CreateCampaignCommand : IRequest<CreateCampaignResponse>
    {
        public string Name { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Installment { get; set; }

        public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, CreateCampaignResponse>
        {
            private readonly ICampainService _campainService;

            public CreateCampaignCommandHandler(ICampainService campainService)
            {
                _campainService = campainService;
            }

            public async Task<CreateCampaignResponse> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
            {
                Campaing campaing = ObjectMapper.Mapper.Map<Campaing>(request);
                _campainService.Add(campaing);

                CreateCampaignResponse response = ObjectMapper.Mapper.Map<CreateCampaignResponse>(campaing);
                return response;
            }
        }
    }
}
