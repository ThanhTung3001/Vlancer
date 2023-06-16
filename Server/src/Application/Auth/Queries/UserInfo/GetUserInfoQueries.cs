using MediatR;
using TSoft.TaskManagement.Application.Common.Interfaces;

namespace TSoft.TaskManagement.Application.Auth.Queries.UserInfo
{
    public record GetUserInfoQueries : IRequest<UserInfoResponseQueries>;

    public class GetUserInfoQueriesHandler : IRequestHandler<GetUserInfoQueries, UserInfoResponseQueries>
    {
        private readonly ICurrentUserService _currentUserService;

        private readonly IIdentityService _identityService;

        public GetUserInfoQueriesHandler(ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<UserInfoResponseQueries> Handle(GetUserInfoQueries request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            if (userId == null)
            {
                throw new Exception($"User not found");
            }

            var userInfo = await _identityService.GetUserInfo(userId);
            return userInfo;

        }
    }
}