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
        bool setCampaigns(List<Campaign> campaignList);
        bool addCampaign(Campaign newCampaign);
    }
}
