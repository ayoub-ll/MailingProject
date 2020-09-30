using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingProject.Model
{
    public class Campaign
    {
        [Key]
        public int campaignId { get; set; }
        [Column]
        [Required]
        public string name { get; set; }

        public Campaign(string name)
        {
            this.name = name;
        }

        public Campaign()
        {
        }
    }
}
