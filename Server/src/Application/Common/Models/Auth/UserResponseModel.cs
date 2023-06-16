namespace TSoft.TaskManagement.Application.Common.Models
{
    public class UserResponseModel
    {
        public string UserName { get; set; }
        
        public string AppUserId { get; set; }

        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }

        public string TokenType { get; set; } = "Bearer";
        public int Expired { get; set; }
    }
}