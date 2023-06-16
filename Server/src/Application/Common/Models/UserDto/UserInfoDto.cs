using TSoft.TaskManagement.Application.Common.Mappings;
using TSoft.TaskManagement.Domain.Entities;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Application.Common.Models.UserDto;

public class UserInfoDto
{
    
    public int Id { get; set; }
    
    public string UserName { get; set; }
    
    public string FullName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public List<UserSkillDto> UserSkills { get; set; }

    public string Description { get; set; }

    public double Rating { get; set; }

    public string Country { get; set; }

    public string Address { get; set; }
}