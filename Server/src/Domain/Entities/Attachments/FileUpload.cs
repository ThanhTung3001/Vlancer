using TSoft.TaskManagement.Domain.Entities.Jobs;

namespace TSoft.TaskManagement.Domain.Entities.Attachments;

public class FileUpload : BaseAuditableEntity
{
    public string FileName { get; set; }

    public string FilePath { get; set; }

    public AttachmentType AttachmentType { get; set; }

    public int JobId { get; set; }
    public Job Job { get; set; }
}