namespace TSoft.TaskManagement.Domain.Entities.Jobs;

public class JobCategory : BaseAuditableEntity
{
    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public string Description { get; set; }

    public string Avatar { get; set; }

    public List<Job> Jobs { get; set; }
}