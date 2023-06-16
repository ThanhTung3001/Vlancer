namespace TSoft.TaskManagement.Domain.Entities.User;

public class UserInfo : BaseAuditableEntity
{
    public Guid AppUserId { get; set; }
    public string? FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<UserSkill> UserSkills { get; set; }
}

public class UserSkill
{
    public int UserId { get; set; }

    public UserInfo UserInfo { get; set; }

    public int SkillId { get; set; }

    public Skill Skill { get; set; }
}