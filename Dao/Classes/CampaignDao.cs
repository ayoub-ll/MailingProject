using MailingProject.Dao.Interfaces;
using MailingProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Dao.Classes
{
    class CampaignDao : ICampaignDao
    {
        /* DB Context */
        private MailingAppDbContext dbContext;

        /* Retourne une campagne depuis son ID */
        public Campaign getCampaignById(int id)
        {
            return this.dbContext.Campaigns.Where(c => c.campaignId.Equals(id)).FirstOrDefault();
        }

        public List<Campaign> getCampaigns()
        {
            return this.dbContext.Campaigns.ToList();
        }
    }
}
