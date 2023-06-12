using System.ComponentModel.DataAnnotations;

namespace TSoft.TaskManagement.Domain.Entities.Jobs;

public class JobGroup : BaseAuditableEntity
{
    [Required] public string GroupName { get; set; } = null!;

    public string? Avatar { get; set; }

    public int? JobParentId { get; set; }

    public JobGroup? JobParent { get; set; }

    public ICollection<JobGroup> GroupChildren = new List<JobGroup>();

    public ICollection<JobItemGroup> JobItems = new List<JobItemGroup>();
}
public class JobItemGroup
{
    public int JobItemId { get; set; }

    public Job? JobItem { get; set; }

    public int JobGroupId { get; set; }

    public JobGroup? JobGroup { get; set; }
}

// one job item have many job group and one group job have many job item