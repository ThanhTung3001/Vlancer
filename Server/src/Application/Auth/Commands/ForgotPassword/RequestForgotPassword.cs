using MediatR;

namespace TSoft.TaskManagement.Application.Auth.Commands.ForgotPassword;

public class RequestForgotPassword : IRequest<string>
{
    public string Email { get; set; }
}

public class ForgotPasswordCommandHandler : IRequestHandler<RequestForgotPassword, string>
{
    public Task<string> Handle(RequestForgotPassword request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}