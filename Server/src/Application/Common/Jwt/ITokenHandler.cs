namespace TSoft.TaskManagement.Application.Common.Jwt
{
    public interface ITokenHandler
    {
        Task<string> GenerateToken(string username);

        Task<string> GenerateTokenForgotPassword(string email);

        bool CheckVerifyToken(string token);
    }
}