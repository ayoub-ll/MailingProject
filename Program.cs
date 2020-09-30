using MailingProject.Controller;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailingProject
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialisation de la DB
            Util.initDb();
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

            MainController.getInstance().StartApp();
        }
    }
}
