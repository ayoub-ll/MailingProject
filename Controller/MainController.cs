using MailingProject.Model;
using MailingProject.Services;
using MailingProject.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailingProject.Controller
{
    class MainController
    {
        public static MainController instance;

        /* DB Service */
        public DbService dbService;

        /* Views */
        private Form1 homeView;
        private CampaignManagement campaignManagementView;
        

        /* Retourne l'instance de ce singleton MainController */
        public static MainController getInstance()
        {
            if (instance == null)
            {
                instance = new MainController();
                instance.campaignManagementView = new CampaignManagement();
                instance.homeView = new Form1();
            }

            return instance;
        }

        /* Affichage de la home page */
        public void StartApp()
        {
            Application.Run(homeView);
        }

        /* Lancement de la fenêtre du Back Office */
        public void StartBackOffice()
        {
            this.campaignManagementView.Show();
            this.homeView.Hide();
            updateCampaignListFromDb();
        }

        /* MAJ de la liste de campagnes depuis la DB MySQL */
        public void updateCampaignListFromDb()
        {
            List<Campaign> dbCampaigns = new List<Campaign>();
            dbCampaigns = this.dbService.campaignDao.getCampaigns();
            this.campaignManagementView.UpdateListFromDb(dbCampaigns);
        }

        /* MAJ de la DB de campagnes depuis les models */
        public void UpdateDbFromCampaignList(ListView.ListViewItemCollection items)
        {
            List<Campaign> dbCampaigns = new List<Campaign>();
            foreach(ListView.ListViewItemCollection item in items)
            {
                dbCampaigns.Add(new Campaign("ok"));
            }
                
        }
    }
}
