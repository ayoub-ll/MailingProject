using MailingProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

                //Ajout des pièces jointes
                if(attachements != null)
                    foreach (string attachment in attachements)
                        mailMessage.Attachments.Add(new Attachment(attachment));

                messagesList.Add(mailMessage);
            }
                

            SmtpClient client = new SmtpClient();
            client.Host = host;
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

        /**
         * Retourne une liste de mails depuis les fichiers d'emails (EmailsFile) passés en paramètre
         */
        public IList<string> GetEmailsFromFiles(ICollection<EmailsFile> recipientsFromFiles)
        {
            IList<string> recipients = new List<string>();

            // Path courrant du projet
            string workingDirectory = Environment.CurrentDirectory;

            foreach (EmailsFile emailsFile in recipientsFromFiles)
            {
                foreach (string line in File.ReadLines((@Directory.GetParent(workingDirectory).Parent.FullName + @"\Storage\EmailsFiles\" + @emailsFile.path)))
                {
                    /* Si l'email est bien valide, on l'ajoute à notre liste de déstinataires */
                    var addr = new System.Net.Mail.MailAddress(line);
                    if (addr.Address == line)
                        recipients.Add(line);
                }
            }

            return recipients;
        }
    }
}
