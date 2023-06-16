namespace TSoft.TaskManagement.Domain.Dto;

public class MailSenderDto
{
    public string FromAddress { get; set; }

    public string FromPassword { get; set; }

    public string ToAddress { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
}