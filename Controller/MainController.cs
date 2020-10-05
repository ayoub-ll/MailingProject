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
        private static MainController instance;

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

        /* Retourne une collection de EmailsFile depuis le campaignId passé en param */
        public ICollection<EmailsFile> getCampaignEmailsFilesById(int campaignId)
        {
            return this.campaignDao.getCampaignEmailsFilesById(campaignId);
        }

        /* Ajoute un nouveau EmailsFile à la campagne dont le campaignId est passé en param */
        public void AddEmailsFileByCampaignId(int campaignSelectedId, EmailsFile newEmailsFile)
        {
            this.campaignDao.addCampaignEmailsFile(campaignSelectedId, newEmailsFile);
        }
    }
}
