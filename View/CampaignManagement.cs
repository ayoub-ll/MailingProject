using MailingProject.Controller;
using MailingProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0)
            {
                this.addCampaign(textBox1.Text);
            }  
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainController.getInstance().UpdateDbFromCampaignList(this.listView1.Items);
            MainController.getInstance().UpdateCampaignListFromDb();
        }
    }
}
