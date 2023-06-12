namespace TSoft.TaskManagement.Application.Common.Jwt
{
    public interface TokenHandler
    {
        Task<string> GenerateToken(string username);
    }
}