using MailingProject.Controller;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

    public class CustomizedMySqlMigrationSqlGenerator : MySqlMigrationSqlGenerator
    {
        #region Override members

        protected override MigrationStatement Generate(CreateIndexOperation op)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                return base.Generate(op);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCulture;
            }
        }
    }
    #endregion
}
