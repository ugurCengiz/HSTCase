using Business.Mappings;
using Business.Servies.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using MediatR;

namespace Business.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
        {
            private readonly IUserService _userService;

            public UpdateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var getUser = await _userService.GetByIdAsync(request.Id);

                var userDto = getUser.Data;

                userDto.UserName = request.UserName;
                userDto.Status = request.Status;

                var updatedUser = await _userService.Update(new UpdateAppUserDto { UserName = userDto.UserName, Status = userDto.Status, Id = userDto.Id });

                return new UpdateUserResponse
                {
                    Id = updatedUser.Data.Id,
                    UserName = updatedUser.Data.UserName,
                    Status = updatedUser.Data.Status
                };
            }
        }
    }


}
