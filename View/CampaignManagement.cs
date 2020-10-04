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
            //this.listView1.Items.
        }

        private void CampaignManagement_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /* Au click du bouton "ajouter" pour les campagnes, on crée la campagne sur la view, en db puis on notifie l'user */
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if(textBox1.TextLength > 0)
            {
                this.addCampaign(textBox1.Text);
            }
            */

            Campaign newCampaign = new Campaign(textBox1.Text); //création de l'objet Campagne
            MainController.getInstance().addCampaign(newCampaign); //ajout de la campagne à la db

            MainController.getInstance().UpdateCampaignListFromDb();


            System.Windows.Forms.MessageBox.Show("Nouvelle campagne ajoutée !");
        }

        private void addCampaign(string campaignName)
        {
            //MainController.getInstance().AddCampaign(new Campaign(textBox1.Text));
            listView1.Items.Add(new ListViewItem(campaignName));
            textBox1.Clear();
        }

        public void UpdateListFromDb(List<Campaign> campaigns)
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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)// Si un élement est bien selectionné (et que c'est pas un click à blanc)
            {
                groupBox2.Visible = true; //Affichage de la partie emails liés à la campagne selectionnée
            } else
            {
                groupBox2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainController.getInstance().UpdateDbFromCampaignList(this.listView1.Items);
            MainController.getInstance().UpdateCampaignListFromDb();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV file (*.csv)|*.csv| Txt file (*.txt)|*.txt"; // file types, that will be allowed to upload
            dialog.Multiselect = true; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                    listView2.Items.Add(new ListViewItem(dialog.FileName));
                    //File.Copy(path, "Model/EmailListFiles");
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
