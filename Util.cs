using MailingProject.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject
{
    class Util
    {
        private static MailingAppDbContext dbContext;

        public static void initDb()
        {
            if (dbContext == null)
                dbContext = new MailingAppDbContext();
            var initializer = new CreateDatabaseIfNotExists<MailingAppDbContext>();
            initializer.InitializeDatabase(dbContext);
        }
    }
}
