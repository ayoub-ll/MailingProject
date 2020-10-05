using MailingProject.Controller;
using MailingProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailingProject.View
{
    public partial class CampaignManagement : Form
    {
        public CampaignManagement()
        {
            InitializeComponent();
            this.Text = "Mailing APP - Campaign Management";
        }

        private void CampaignManagement_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /* Au click du bouton "ajouter" pour les campagnes, on crée la campagne sur la view, en db puis on notifie notre cher utilisateur sur la view via un MessageBox*/
        private void button1_Click(object sender, EventArgs e)
        {
            Campaign newCampaign = new Campaign(textBox1.Text); //Création de l'objet Campagne
            MainController.getInstance().addCampaign(newCampaign); //Ajout de la campagne à la db
            MainController.getInstance().UpdateCampaignListFromDb(); //Mise à jour de la liste sur la view depuis la db suite à l'ajout de la nouvelle campagne

            System.Windows.Forms.MessageBox.Show("Nouvelle campagne ajoutée !");
        }

        /* Ajout d'une campagne sur la VIEW depuis le nom passé en param */
        private void addCampaign(string campaignName)
        {
            listView1.Items.Add(new ListViewItem(campaignName));
            textBox1.Clear();
        }

        /**
         * Mise à jour de la liste des campagnes en view depuis celles passés en param
         */
        public void UpdateCampaignListFromDb(List<Campaign> campaigns)
        {
            listView1.Clear();

            foreach(Campaign campaign in campaigns)
            {
                ListViewItem campaignViewTime = new ListViewItem();
                ListViewItem.ListViewSubItem campaignIdSubItem = new ListViewItem.ListViewSubItem();

                campaignViewTime.Text = campaign.name;
                campaignIdSubItem.Name = "CampaignId";
                campaignIdSubItem.Text = campaign.campaignId.ToString();

                campaignViewTime.SubItems.Add(campaignIdSubItem);
                listView1.Items.Add(campaignViewTime);
            }
        }

        /**
         * Mise à jour de la liste des fichires d'emails en view depuis celles passés en param
         */
        private void UpdateEmailsFileListFromDb(ICollection<EmailsFile> emailsFiles)
        {
            listView2.Clear();

            foreach (EmailsFile emailsFile in emailsFiles)
            {
                ListViewItem campaignViewTime = new ListViewItem();
                ListViewItem.ListViewSubItem campaignIdSubItem = new ListViewItem.ListViewSubItem();

                campaignViewTime.Text = emailsFile.path;
                campaignIdSubItem.Name = "emailsFileId";
                campaignIdSubItem.Text = emailsFile.emailsFileId.ToString();

                campaignViewTime.SubItems.Add(campaignIdSubItem);
                listView2.Items.Add(campaignViewTime);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        /* Au click d'une campagne, on met à jour la partie mail listing */
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)//Si un élement est bien selectionné (et que c'est pas un click à blanc)
            {
                groupBox2.Visible = true; //Affichage de la partie emails liés à la campagne selectionnée

                /* clear de la partie listing mails */
                this.listView2.Clear();
                this.listView3.Clear();

                this.ShowCampaignInformationsFromDb(); //Récupération et affichage de la liste des fichiers d'emails liés à cette campagne
                this.UpdateEmailsListFromDb(); //Récupération et affichage de la liste d'emails liés à la campagne selectionnée
            } else
            {
                groupBox2.Visible = false;
            }
        }

        /*
         * Récupération et affichage des paths des fichiers d'emails associés à la campagne selectionnée
         */
        private void ShowCampaignInformationsFromDb()
        {
            //Récupération des paths des fichiers d'emails liés à la campagne selectionnée sur cette view
            ICollection<EmailsFile> emailsFiles = MainController.getInstance().getCampaignEmailsFilesById(Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));

            /*
             * On parcours les fichiers d'emails récupérés en DB
             * Pour chacun, on l'affiche sur la listView2 (qui correspond à la liste des fichiers associés à la campagne selectionnée)
             * Et pour garder l'id de cet EmailsFile, on l'insère en subitem au cas où on en a besoin
             */
            foreach(EmailsFile emailFile in emailsFiles)
            {
                ListViewItem emailFileListViewItem = new ListViewItem(emailFile.path);
                ListViewItem.ListViewSubItem emailFileListViewSubItem = new ListViewItem.ListViewSubItem();

                emailFileListViewSubItem.Name = "EmailsFileId";
                emailFileListViewSubItem.Text = emailFile.emailsFileId.ToString();

                emailFileListViewItem.SubItems.Add(emailFileListViewSubItem);

                listView2.Items.Add(emailFileListViewItem);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        /**
         * Au click du bouton "Ajouter fichier", on ouvre la fenêtre de sélection d'un fichier de mail
         * Puis on ajoute ce fichier sur la view et en DB
         */
        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV file (*.csv)|*.csv| Txt file (*.txt)|*.txt"; // file types, that will be allowed to upload
            dialog.Multiselect = true; // allow/deny user to upload more than one file at a time
            int campaignSelectedId = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text); //campaignId de la campagne selectionnée

            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding()))
                {
                    EmailsFile newEmailsFile = new EmailsFile(dialog.SafeFileName);

                    MainController.getInstance().AddEmailsFileByCampaignId(campaignSelectedId, newEmailsFile); //Ajout du nouveau EmailsFile associé à la campagne selectionnée
                    this.UpdateEmailsFileListFromDb(MainController.getInstance().getCampaignEmailsFilesById(campaignSelectedId)); //Mise à jour de la liste de fichiers d'emails

                    //File.Copy((@path), "Storage/EmailsFiles/"+dialog.SafeFileName); //Création d'une copie du fichier selectionné, à l'intérieur du projet
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        /**
         * Au click du boutton "Ajouter email", on ajout de l'email en db (via controller and dao)
         */
        private void button3_Click(object sender, EventArgs e)
        {
            int campaignSelectedId = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text); //campaignId de la campagne selectionnée

            //Ajout de l'email en db (via controller and dao)
            MainController.getInstance().addEmailByCampaignId(campaignSelectedId, new Email(this.textBox2.Text));
            this.UpdateEmailsListFromDb(); //Mise à jour de la liste de fichiers d'emails

            this.textBox2.Clear(); //Nettoyage de la textbox contenant le mail saisi
        }

        /**
         * Mise à jour de la liste d'emails en view depuis celles passés en param
         */
        private void UpdateEmailsListFromDb()
        {
            listView3.Clear();

            int campaignSelectedId = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text); //campaignId de la campagne selectionnée

            foreach (Email email in MainController.getInstance().getCampaignEmailsById(campaignSelectedId))
            {
                ListViewItem campaignViewTime = new ListViewItem();
                ListViewItem.ListViewSubItem campaignIdSubItem = new ListViewItem.ListViewSubItem();

                campaignViewTime.Text = email.email;
                campaignIdSubItem.Name = "emailId";
                campaignIdSubItem.Text = email.emailId.ToString();

                campaignViewTime.SubItems.Add(campaignIdSubItem);
                listView3.Items.Add(campaignViewTime);
            }
        }

        /* Au click d'un e-mail, affichage du bouton supprimer */
        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView3.SelectedItems.Count == 1)
            {
                this.button4.Visible = true;
            } else
            {
                this.button4.Visible = false;
            }
        }

        private void listView3_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.listView3.SelectedItems.Count == 1)
            {
                this.listView3.SelectedItems[0].BeginEdit();
            }
        }

        /* Au click du bouton rouge "supprimer un email", on le retire de la DB puis mise à jour de la view depuis la db */
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listView3.SelectedItems.Count == 1)
            {
                MainController.getInstance().removeEmailById(Convert.ToInt32(listView3.SelectedItems[0].SubItems[1].Text));
                this.UpdateEmailsListFromDb();
            }
        }
    }
}
