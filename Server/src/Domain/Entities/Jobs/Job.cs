using System.ComponentModel.DataAnnotations;
using TSoft.TaskManagement.Domain.Entities.Attachments;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Domain.Entities.Jobs;

public class Job : BaseAuditableEntity
{
    [Required] public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime FinishTime { get; set; }
    public decimal Budget { get; set; }
    public List<JobItemGroup> JobItemGroups = new List<JobItemGroup>();
    public int CategoryId { get; set; }
    public JobCategory? JobCategory { get; set; }
    public List<UserSkill> UserSkills = new List<UserSkill>();
    public PriorityLevel PriorityLevel { get; set; }
    public List<FileUpload> Attachments = new List<FileUpload>();
}