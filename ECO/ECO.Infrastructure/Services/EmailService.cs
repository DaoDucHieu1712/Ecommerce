using ECO.Application.Services;
using ECO.Infrastructure.MailHelper;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettingModel _emailSetting;
        public EmailService(IOptionsMonitor<MailSettingModel> emailSetting)
        {
            _emailSetting = emailSetting.CurrentValue;
        }

        public async Task SendEmailAsync(MailModel mailModel)
        {
            using (var emailMessage = new MimeMessage())
            {
                MailboxAddress emailFrom = new MailboxAddress(_emailSetting.SenderName, _emailSetting.SenderEmail);
                emailMessage.From.Add(emailFrom);
                foreach (var receiver in mailModel.To)
                {
                    MailboxAddress emailTo = new MailboxAddress("Receiver", receiver);
                    emailMessage.To.Add(emailTo);
                }

                emailMessage.Subject = mailModel.Subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = mailModel.Body;
                emailMessage.Body = bodyBuilder.ToMessageBody();
                using (var mailClient = new SmtpClient())
                {
                    await mailClient.ConnectAsync(_emailSetting.Server, _emailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
                    await mailClient.AuthenticateAsync(_emailSetting.UserName, _emailSetting.Password);
                    await mailClient.SendAsync(emailMessage);
                    await mailClient.DisconnectAsync(true);
                }
            }
        }
    }
}
