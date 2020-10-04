using MailingProject.Dao.Classes;
using MailingProject.Dao.Interfaces;
using MailingProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Services
{
    class DbService
    {
       
        /* CampaignDao */
        public ICampaignDao campaignDao;

        public DbService()
        {
            this.campaignDao = new CampaignDao();
        }

        /*
        internal void updateCampaignsDb(List<Campaign> dbCampaigns)
        {
            this.campaignDao.setCampaigns(dbCampaigns);
        }
        */
    }
}
