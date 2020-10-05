using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Model
{
    public class Email
    {
        [Key]
        public int emailId { get; set; }
        public string email { get; set; }

        public Email(string email)
        {
            this.email = email;
        }
        public Email()
        {

        }
    }
}
