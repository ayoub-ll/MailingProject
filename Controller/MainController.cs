using MailingProject.Dao.Classes;
using MailingProject.Dao.Interfaces;
using MailingProject.Model;
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

        /* DAO */
        public ICampaignDao campaignDao;

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
                instance.campaignDao = new CampaignDao();
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
        }

        /* MAJ de la liste de campagnes depuis la DB MySQL */
        public void UpdateCampaignListFromDb()
        {
            List<Campaign> dbCampaigns = new List<Campaign>();
            dbCampaigns = this.campaignDao.getCampaigns();
            this.campaignManagementView.UpdateCampaignListFromDb(dbCampaigns);
        }

        /* Ajout d'une nouvelle campagne à la DB via le dbService */
        public void addCampaign(Campaign newCampaign)
        {
            this.campaignDao.addCampaign(newCampaign);
        }

        public ICollection<EmailsFile> getCampaignEmailsFilesById(int campaignId)
        {
            return this.campaignDao.getCampaignEmailsFilesById(campaignId);
        }

        public void AddEmailsFileByCampaignId(int campaignSelectedId, EmailsFile newEmailsFile)
        {
            this.campaignDao.addCampaignEmailsFile(campaignSelectedId, newEmailsFile);
        }

        /* MAJ de la DB de campagnes depuis les models */
        /*
        public void UpdateDbFromCampaignList(ListView.ListViewItemCollection items)
        {
            List<Campaign> dbCampaigns = new List<Campaign>();
            foreach(System.Windows.Forms.ListViewItem item in items)
            {
                Campaign campaign = new Campaign(item.Text);

                //On détecte si c'est une campagne existant en checkant s'il a un ID en subItem
                if (item.SubItems.Count > 1)
                {
                    //Récupération de l'id du nouvel item crée (puisqu'il n'a pas d'id ici)
                    //qu'on a préalablement installé en subItem
                    campaign.campaignId = Convert.ToInt32(item.SubItems[1].Text);
                }

                dbCampaigns.Add(campaign);
            }
            this.dbService.updateCampaignsDb(dbCampaigns);
        }
        */
    }
}
