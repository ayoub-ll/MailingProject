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
            try
            {
                this.dbContext.Campaigns.AddOrUpdate(newCampaign);
                this.dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /* Retourne une campagne depuis son ID */
        public Campaign getCampaignById(int id)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(id)).FirstOrDefault();
        }

        public List<Campaign> getCampaigns()
        {
            return this.dbContext.Campaigns.ToList();
        }

        /*
        public bool setCampaigns(List<Campaign> campaignList)
        {
            foreach(Campaign campaign in campaignList)
            {
                this.dbContext.Campaigns.AddOrUpdate(campaign);
            }
            this.dbContext.SaveChanges();
            return true;
        }
        */
    }
}
