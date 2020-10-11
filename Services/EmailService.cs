using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Services
{
    class EmailService : IEmailService
    {
        public bool SendEmail(string host, int port, string smtpUsername, string smtpPassword, string sender, string subject, string body, IList<string> recipients, IList<string> attachements)
        {
            string to = recipients.First();
            string from = sender;
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = body;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.gmx.com";
            client.Port = port;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
                return false;
            }
        }
    }
}
