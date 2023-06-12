using TSoft.TaskManagement.Application.Common.Interfaces;
using TSoft.TaskManagement.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace TSoft.TaskManagement.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    private readonly IConfiguration _config;

    public IdentityService(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService,
        IConfiguration config
        )
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _config = config;
        _signInManager = signInManager;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser { UserName = userName, Email = userName, };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<UserResponseModel> LoginAsync(string UserName, string Password)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(UserName);
            int expired = int.Parse(_config["Jwt:Expired"]!);
            if (user == null) throw new Exception($"Username: {UserName} not found");
            var roles = await _userManager.GetRolesAsync(user);
            var loginResult = await _signInManager.CheckPasswordSignInAsync(user: user, password: Password, false);
            if (loginResult.Succeeded)
            {

                var claims = new[]
                            {
                new Claim(ClaimTypes.Name, user.UserName!),
                 new Claim(ClaimTypes.NameIdentifier, user.Id!),

            };

                roles.ToList().ForEach(e => claims.Append(new Claim(ClaimTypes.Role, e!)));

                // Tạo khóa bí mật
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

                // Tạo thông tin xác thực
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Tạo token
                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(expired),
                    signingCredentials: creds
                    );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                // Trả về token
                return new UserResponseModel()
                {
                    UserName = UserName,
                    JwtToken = jwtToken,
                    Expired = expired
                };
            }

            throw new Exception("Username or password invalid");
        }
        catch (System.Exception)
        {

            throw;
        }
    }

}