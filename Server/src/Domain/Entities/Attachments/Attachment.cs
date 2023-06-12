using TSoft.TaskManagement.Domain.Entities.Jobs;

namespace TSoft.TaskManagement.Domain.Entities.Attachments;

public class Attachment : BaseAuditableEntity
{
    public string FileName { get; set; }

    public AttachmentType AttachmentType { get; set; }

    public string FilePath { get; set; }

    public string RootOrigin { get; set; }

    public int JobId { get; set; }
    public Job Job { get; set; }
}