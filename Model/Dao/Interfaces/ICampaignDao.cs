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
        Campaign getCampaignById(int id);
        List<Campaign> getCampaigns();
        bool addCampaign(Campaign newCampaign);
        ICollection<EmailsFile> getCampaignEmailsFilesById(int id);
        bool addCampaignEmailsFile(int campaignId, EmailsFile newEmailsFile);
        bool addCampaignEmail(int campaignSelectedId, Email newEmail);
        ICollection<Email> getCampaignEmailsById(int campaignId);
    }
}
