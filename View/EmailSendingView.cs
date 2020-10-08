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
    public partial class EmailSendingView : Form
    {

        public Campaign selectedCampaign { get; set; }

        public EmailSendingView()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /**
         * Affichage du nom de la campagne selectionnée dans l'IHM précedente
         */
        public void SetCampaignNameLabel(string campaignName)
        {
            this.label5.Text = campaignName;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
