using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Services
{
    interface IEmailService
    {
        bool SendEmail(string host, int port, string smtpUsername, string smtpPassword, string sender, string subject, string body, ICollection<string> recipients, IList<string> attachements);
    }
}
