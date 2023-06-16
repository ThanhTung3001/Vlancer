using MediatR;
using TSoft.TaskManagement.Application.Common.Interfaces;
using TSoft.TaskManagement.Application.Common.Models;

namespace TSoft.TaskManagement.Application.Auth.Commands.Register;

public class RegisterCommand : IRequest<string>
{
    public string UserName { get; set; }

    public string Password { get; set; }
    
    public string FullName { get; set; }
    
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
{
    private readonly IIdentityService _identityService;

    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateUserAsync(userName: request.UserName, password: request.Password,
            FullName: request.FullName);
        return result.UserId;
    }
}