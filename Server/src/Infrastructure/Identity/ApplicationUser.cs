using Microsoft.AspNetCore.Identity;
using TSoft.TaskManagement.Application.Auth.Queries.UserInfo;
using TSoft.TaskManagement.Application.Common.Mappings;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Infrastructure.Identity;

public class ApplicationUser : IdentityUser,IMapFrom<UserInfoResponseQueries>
{

    public string FullName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public List<Skill> UserSkills { get; set; }

    public string? Description { get; set; }

    public double Rating { get; set; }

    public string? Country { get; set; }

    public string? Address { get; set; }
}