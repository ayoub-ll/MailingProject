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
        public bool SendEmail(string host, int port, string smtpUsername, string smtpPassword, string sender, string subject, string body, ICollection<string> recipients, IList<string> attachements)
        {
            string from = sender;
            List<MailMessage> messagesList = new List<MailMessage>();
            foreach (string recipient in recipients)
            {
                MailMessage mailMessage = new MailMessage(sender, recipient);           
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                messagesList.Add(mailMessage);
            }
                

            SmtpClient client = new SmtpClient();
            client.Host = "mail.gmx.com";
            client.Port = port;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            try
            {   //Pour chaque email dans la campagne selectionné, envoi du mail
                foreach(MailMessage mailMessage in messagesList)
                    client.Send(mailMessage);
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
