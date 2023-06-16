using MediatR;
using TSoft.TaskManagement.Application.Common.Interfaces;
using TSoft.TaskManagement.Application.Common.Jwt;
using TSoft.TaskManagement.Application.Common.Models;

namespace TSoft.TaskManagement.Application.Auth.Commands.Authentication
{
    public class AuthApiCommands : IRequest<UserResponseModel>
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }
    }

    public class AuthApiCommandsHandler : IRequestHandler<AuthApiCommands, UserResponseModel>
    {

        private readonly IIdentityService _identityService;

        public AuthApiCommandsHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        async Task<UserResponseModel> IRequestHandler<AuthApiCommands, UserResponseModel>.Handle(AuthApiCommands request, CancellationToken cancellationToken)
        {
            var user = await _identityService.LoginAsync(request.UserName!, request.Password!);
            return user;
        }
    }
}