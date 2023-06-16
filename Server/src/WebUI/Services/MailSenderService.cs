using System.Net;
using System.Net.Mail;
using TSoft.TaskManagement.Application.Common.Interfaces;
using TSoft.TaskManagement.Domain.Dto;

namespace WebUI.Services;

public class MailSenderService : IMailSenderService
{
    private readonly IConfiguration _config;

    public MailSenderService(IConfiguration config)
    {
        _config = config;
    }

    public void SendEmail(MailSenderDto senderDto)
    {
        {
            var fromAddress = new MailAddress(senderDto.FromAddress, _config["AppInfo:AppName"]);
            var toAddress = new MailAddress(senderDto.ToAddress, "Client Name");
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, _config["AppInfo:AppEmailPassword"])
            };

            using var message =
                new MailMessage(fromAddress, toAddress) { Subject = senderDto.Subject, Body = senderDto.Body };
            smtp.Send(message);
        }
    }
}