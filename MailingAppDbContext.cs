using MailingProject.Model;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class MailingAppDbContext : DbContext
    {
        public MailingAppDbContext() : base("dbConnection")
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailsFile> EmailsFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
