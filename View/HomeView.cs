using MailingProject.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailingProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Mailing APP - Home page";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;//1 second
            timer1.Tick += new System.EventHandler(upgradeProgressBar);
            timer1.Start();
            progressBar1.Maximum = 5;
            progressBar1.Visible = true;

            await Task.Run(() => MainController.getInstance().UpdateCampaignListFromDb());
            timer1.Stop();
            MainController.getInstance().StartBackOffice(); // Switch de la homeView à CampaignManagementView
        }

        private void upgradeProgressBar(object sender, EventArgs e)
        {
            if(progressBar1.Value < 5)
                progressBar1.Value++;
        }
    }
}
