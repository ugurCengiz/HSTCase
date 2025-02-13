using Business.Servies.Abstract;
using MediatR;

namespace Business.Features.Orders.Queries.GetAvailableInstallments
{
    public class GetAvailableInstallmentsQuery : IRequest<List<int>>
    {
        public decimal TotalAmount { get; set; }

        public class GetAvailableInstallmentsQueryHandler : IRequestHandler<GetAvailableInstallmentsQuery, List<int>>
        {
            private readonly ICampainService _campainService;

            public GetAvailableInstallmentsQueryHandler(ICampainService campainService)
            {
                _campainService = campainService;
            }

            public async Task<List<int>> Handle(GetAvailableInstallmentsQuery request, CancellationToken cancellationToken)
            {
               return await _campainService.GetAvailableInstallments(request.TotalAmount);
            }
        }
    }
}
