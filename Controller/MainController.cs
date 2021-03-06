﻿using MailingProject.Dao.Classes;
using MailingProject.Dao.Interfaces;
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
        private static MainController instance;

        /* DAO */
        public ICampaignDao campaignDao;

        /* Views */
        private Form1 homeView;
        private CampaignManagement campaignManagementView;
        private EmailSendingView emailSendingView;

        /* Services */
        private IEmailService emailService;

        /* Retourne l'instance de ce singleton MainController */
        public static MainController getInstance()
        {
            if (instance == null)
            {
                instance = new MainController();
                instance.homeView = new Form1();
                instance.campaignDao = new CampaignDao();
                instance.campaignManagementView = new CampaignManagement();
                instance.emailService = new EmailService();
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
            if(this.emailSendingView != null)
                this.emailSendingView.Hide();

        }

        /* MAJ de la liste de campagnes depuis la DB MySQL */
        public void UpdateCampaignListFromDb()
        {
            List<Campaign> dbCampaigns = new List<Campaign>();
            dbCampaigns = this.campaignDao.GetCampaigns();
            this.campaignManagementView.UpdateCampaignListFromDb(dbCampaigns);
        }

        /**
         * Fonction intérmerdiaire du controller permettant l'envoi du mail depuis les informations de la vue
         * et en faisant appel au MailService (contenant le SmtpClient)
         */
        public bool SendEmail(bool emailTestBool, string host, int port, string smtpUsername, string smtpPassword, string testEmail, string sender, string subject, string body, ICollection<Email> recipients, ICollection<EmailsFile> recipientsFromFiles, IList<string> attachments)
        {
            IList<string> recipientsList = new List<string>();

            // Récupération des emails en string de chaque objet de type Email dans la collection recipients
            foreach (Email email in recipients)
                recipientsList.Add(email.email);

            if(recipientsFromFiles != null && recipientsFromFiles.Count > 0)
            {
                //Appel au MailService afin de récupérer les mails depuis les fichiers liés à la Campaign courrante
                foreach (string email in emailService.GetEmailsFromFiles(recipientsFromFiles))
                    recipientsList.Add(email);
            }

            return this.emailService.SendEmail(host, port, smtpUsername, smtpPassword, sender, subject, body, recipientsList, attachments);
        }

        /* Ajout d'une nouvelle campagne à la DB via le dbService */
        public void AddCampaign(Campaign newCampaign)
        {
            this.campaignDao.AddCampaign(newCampaign);
        }

        /* Retourne une collection de EmailsFile depuis le campaignId passé en param */
        public ICollection<EmailsFile> GetCampaignEmailsFilesById(int campaignId)
        {
            return this.campaignDao.GetCampaignEmailsFilesById(campaignId);
        }

        /* Ajoute un nouveau EmailsFile à la campagne dont le campaignId est passé en param */
        public void AddEmailsFileByCampaignId(int campaignSelectedId, EmailsFile newEmailsFile)
        {
            this.campaignDao.AddCampaignEmailsFile(campaignSelectedId, newEmailsFile);
        }

        /* Ajoute un nouveau Email à la campagne dont le campaignId est passé en param */
        public void AddEmailByCampaignId(int campaignSelectedId, Email newEmail)
        {
            this.campaignDao.AddCampaignEmail(campaignSelectedId, newEmail);
        }

        /* Retourne la liste d'emails liés à la campagne dont le campaignId est passé en param */
        public ICollection<Email> GetCampaignEmailsById(int campaignId)
        {
            return this.campaignDao.GetCampaignEmailsById(campaignId);
        }

        /* Suppression d'un Email depuis son ID */
        public void RemoveEmailById(int emailId)
        {
            this.campaignDao.RemoveEmailById(emailId);
        }

        /* Retourne un objet Email depuis l'id passé en paramètre */
        public Email GetEmailById(int emailId)
        {
            return this.campaignDao.GetEmailById(emailId);
        }

        /* Update en DB l'email passé en paramètre */
        public void UpdateEmail(Email email)
        {
            this.campaignDao.UpdateEmail(email);
        }

        /**
         * Switch de CampaignManagementView à l'IHM d'envoi d'email
         */
        public void StartEmailSendingView(Campaign campaign)
        {
            if(this.emailSendingView == null)
                this.emailSendingView = new EmailSendingView();

            this.emailSendingView.Show();
            this.emailSendingView.selectedCampaign = campaign;
            this.emailSendingView.SetCampaignNameLabel(campaign.name);

            this.emailSendingView.ClearAttachmentsList();//Clear de la liste des pièces jointes 

            this.campaignManagementView.Hide();
        }

        /**
         * Retourne la campagne depuis son campaignId
         */
        public Campaign GetCampaignById(int campaignId)
        {
            return this.campaignDao.GetCampaignById(campaignId);
        }
    }
}
