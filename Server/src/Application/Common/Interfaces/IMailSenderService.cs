using System.Net;
using System.Net.Mail;
using TSoft.TaskManagement.Domain.Dto;

namespace TSoft.TaskManagement.Application.Common.Interfaces;

public interface IMailSenderService
{
    public void SendEmail(MailSenderDto senderDto);

}