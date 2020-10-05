using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Model
{
    public class EmailsFile
    {
        [Key]
        public int emailsFileId { get; set; }
        public string path { get; set; }

        public EmailsFile()
        {

        }

        public EmailsFile(string path)
        {
            this.path = path;
        }
    }
}
