using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Services
{
    interface IEmailService
    {
        bool SendEmail(string server, string sender, string subject, string body, IList<string> recipients, IList<string> attachements);
    }
}
