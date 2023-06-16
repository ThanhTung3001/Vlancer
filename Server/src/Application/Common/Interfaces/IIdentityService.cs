using TSoft.TaskManagement.Application.Auth.Queries.UserInfo;
using TSoft.TaskManagement.Application.Common.Models;

namespace TSoft.TaskManagement.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, string FullName);

    Task<Result> DeleteUserAsync(string userId);

    Task<UserResponseModel> LoginAsync(string UserName, string Password);
    Task<UserInfoResponseQueries> GetUserInfo(string userId);

    Task<string> SendCodeChangePassword(string email);


}