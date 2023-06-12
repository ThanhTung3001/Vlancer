using MediatR;
using TSoft.TaskManagement.Application.Common.Interfaces;

namespace TSoft.TaskManagement.Application.Auth
{
    public record GetUserInfoQueries : IRequest<UserInfoResponseQueries> { }

    public class GetUserInfoQueriesHandler : IRequestHandler<GetUserInfoQueries, UserInfoResponseQueries>
    {
        private readonly ICurrentUserService _currentUserService;

        public GetUserInfoQueriesHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<UserInfoResponseQueries> Handle(GetUserInfoQueries request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (userId != null)
            {
                return new UserInfoResponseQueries()
                {
                    UserName = userId
                };
            }
            throw new Exception($"User not found $");
        }
    }

}