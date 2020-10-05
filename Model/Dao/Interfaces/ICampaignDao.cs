using MailingProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Dao.Interfaces
{
    interface ICampaignDao
    {
        /* Campaign */
        Campaign GetCampaignById(int id);
        List<Campaign> GetCampaigns();
        bool AddCampaign(Campaign newCampaign);

        /* EmailsFile */
        ICollection<EmailsFile> GetCampaignEmailsFilesById(int id);
        bool AddCampaignEmailsFile(int campaignId, EmailsFile newEmailsFile);

        /* Email */
        bool AddCampaignEmail(int campaignSelectedId, Email newEmail);
        ICollection<Email> GetCampaignEmailsById(int campaignId);
        bool RemoveEmailById(int emailId);
        Email getEmailById(int emailId);
        bool updateEmail(Email email);
    }
}
