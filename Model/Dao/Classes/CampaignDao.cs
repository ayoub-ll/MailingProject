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
        public bool AddCampaign(Campaign newCampaign)
    {
            this.dbContext.Campaigns.AddOrUpdate(newCampaign);
            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }

        /* Retourne une campagne depuis son ID */
        public Campaign GetCampaignById(int id)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(id)).FirstOrDefault();
        }

        /* Retourne les EmailsFile depuis le campaignId */
        public ICollection<EmailsFile> GetCampaignEmailsFilesById(int campaignId)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(campaignId)).Include("emailsFileList").FirstOrDefault().emailsFileList;
        }

        /* Retourne toutes les campagnes présentes en DB */
        public List<Campaign> GetCampaigns()
        {
            return this.dbContext.Campaigns.ToList();
        }

        /* Ajoute un EmailsFile en DB à la campagne dont l'id est donné en param*/
        public bool AddCampaignEmailsFile(int campaignId, EmailsFile newEmailsFile)
        {
            Campaign campaign = this.GetCampaignById(campaignId);
            campaign.emailsFileList.Add(newEmailsFile);

            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }

        /* Ajoute un nouvel email (passé en 2nd param) à la campagne dont l'id est passé en 1er param */
        public bool AddCampaignEmail(int campaignSelectedId, Email newEmail)
        {
            Campaign campaign = this.dbContext.Campaigns.Where(c => c.campaignId.Equals(campaignSelectedId)).Include("emailList").FirstOrDefault();
            campaign.emailList.Add(newEmail);

            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }

        /* Retourne la liste d'emails associés à la campagne dont l'id est passé en param */
        public ICollection<Email> GetCampaignEmailsById(int campaignId)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(campaignId)).Include("emailList").FirstOrDefault().emailList;
        }

        /* Supprime l'email dont l'id est passé en param */
        public bool RemoveEmailById(int emailId)
        {
            this.dbContext.Emails.Remove(this.dbContext.Emails.Where(e => e.emailId.Equals(emailId)).FirstOrDefault());

            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }

        public Email getEmailById(int emailId)
        {
            return this.dbContext.Emails.Where(e => e.emailId.Equals(emailId)).FirstOrDefault();
        }

        public bool updateEmail(Email email)
        {
            this.dbContext.Emails.AddOrUpdate(email);

            int ret = this.dbContext.SaveChanges();
            return ret != 0 ? true : false;
        }
    }
}
