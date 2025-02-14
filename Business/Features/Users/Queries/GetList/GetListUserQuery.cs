using Business.Servies.Abstract;
using Core.Entities.Concrete;
using MediatR;

namespace Business.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<List<GetListUserDto>>
    {
        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, List<GetListUserDto>>
        {
            private readonly IUserService _userService;

            public GetListUserQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<List<GetListUserDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                var response = await _userService.GetAllAsync();

                return response.Data.Select(user => new GetListUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Status= user.Status
                }).ToList();

            }
        }
    }
}
