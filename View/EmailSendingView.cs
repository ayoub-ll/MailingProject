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

        /**
         * Au click du bouton "envoyer à un e-mail de test"
         */
        private void button3_Click(object sender, EventArgs e)
        {
            /* Si l'email est bien valide, on envoi le mail de test */
            var addr = new System.Net.Mail.MailAddress(textBox5.Text);
            if (addr.Address == textBox5.Text)
            {
                IList<Email> recipients = new List<Email>();
                recipients.Add(new Email(textBox5.Text));

                if (MainController.getInstance().SendEmail(true, textBox4.Text, Convert.ToInt32(textBox6.Text), textBox7.Text, textBox8.Text, textBox5.Text, textBox1.Text, textBox3.Text, textBox3.Text, recipients))
                    System.Windows.Forms.MessageBox.Show("Mail envoyé !");
                else
                    System.Windows.Forms.MessageBox.Show("Problème lors de l'envoi du mail. Veuillez vérifier vos paramètres SMTP");
            }
        }

        /**
         * Au click du bouton "envoyer e-mail", on envoi le mail à toute la liste configuré dans l'IHM
         * de la Campaign
         */
        private void button7_Click(object sender, EventArgs e)
        {
            MainController.getInstance().SendEmail(false, textBox4.Text, Convert.ToInt32(textBox6.Text), textBox7.Text, textBox8.Text, textBox5.Text, textBox1.Text, textBox3.Text, textBox3.Text, selectedCampaign.emailList);
            System.Windows.Forms.MessageBox.Show("Mail envoyé !");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
