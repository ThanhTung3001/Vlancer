using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TSoft.TaskManagement.Application.Common.Interfaces;
using TSoft.TaskManagement.Application.Common.Jwt;


namespace TSoft.TaskManagement.Infrastructure.Identity
{
    public class IdentityTokenHandler : ITokenHandler
    {
        private readonly IApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _config;

        public IdentityTokenHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        public async Task<string> GenerateToken(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username.Trim());
                if (user != null)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.UserName!) };

                    // Tạo khóa bí mật
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

                    // Tạo thông tin xác thực
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Tạo token
                    var token = new JwtSecurityToken(
                        issuer: _config["Jwt:Issuer"],
                        audience: _config["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(100000),
                        signingCredentials: creds
                    );

                    // Trả về token
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }

                throw new Exception("User not found");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Task<string> GenerateTokenForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public bool CheckVerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true
            };

            try
            {
                SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return true;
            }
            catch (SecurityTokenException)
            {
                // Invalid token
                return false;
            }
        
        }
    }
}