using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.MailHelper
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailModel mailModel);
    }
}
