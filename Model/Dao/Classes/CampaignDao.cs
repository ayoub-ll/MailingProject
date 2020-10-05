using MailingProject.Dao.Interfaces;
using MailingProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Dao.Classes
{
    class CampaignDao : ICampaignDao
    {
        /* DB Context */
        private MailingAppDbContext dbContext;

        public CampaignDao()
        {
            this.dbContext = new MailingAppDbContext();
        }

        /* Ajout d'une nouvelle campaign en db */
        public bool addCampaign(Campaign newCampaign)
    {
            this.dbContext.Campaigns.AddOrUpdate(newCampaign);
            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }

        /* Retourne une campagne depuis son ID */
        public Campaign getCampaignById(int id)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(id)).FirstOrDefault();
        }

        /* Retourne les EmailsFile depuis le campaignId */
        public ICollection<EmailsFile> getCampaignEmailsFilesById(int campaignId)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(campaignId)).Include("emailsFileList").FirstOrDefault().emailsFileList;
        }

        /* Retourne toutes les campagnes présentes en DB */
        public List<Campaign> getCampaigns()
        {
            return this.dbContext.Campaigns.ToList();
        }

        /* Ajoute un EmailsFile en DB à la campagne dont l'id est donné en param*/
        public bool addCampaignEmailsFile(int campaignId, EmailsFile newEmailsFile)
        {
            Campaign campaign = this.getCampaignById(campaignId);
            campaign.emailsFileList.Add(newEmailsFile);

            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }

        public bool addCampaignEmail(int campaignSelectedId, Email newEmail)
        {
            Campaign campaign = this.dbContext.Campaigns.Where(c => c.campaignId.Equals(campaignSelectedId)).Include("emailList").FirstOrDefault();
            campaign.emailList.Add(newEmail);

            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }

        public ICollection<Email> getCampaignEmailsById(int campaignId)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(campaignId)).Include("emailList").FirstOrDefault().emailList;
        }
    }
}
