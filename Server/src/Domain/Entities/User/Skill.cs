using TSoft.TaskManagement.Domain.Entities.Jobs;

namespace TSoft.TaskManagement.Domain.Entities.User;

public class Skill : BaseAuditableEntity
{
    public string Name { get; set; } = null!;

    public JobGroup JobGroup { get; set; }

    public List<UserSkill> GroupUserSkills { get; set; } = new List<UserSkill>();
}