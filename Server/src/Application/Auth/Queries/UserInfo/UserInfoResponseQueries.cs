
namespace TSoft.TaskManagement.Application.Auth.Queries.UserInfo
{
    public class UserInfoResponseQueries
    {
        public UserInfoResponseQueries(string id = null, string? userName = null, string fullName = null,
            DateTime dateOfBirth = default, string description = null, double rating = default, string country = null,
            string address = null)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            UserName = userName;
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            DateOfBirth = dateOfBirth;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Rating = rating;
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public string Id { get; set; }
    
        public string? UserName { get; set; }
    
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }
    }

}