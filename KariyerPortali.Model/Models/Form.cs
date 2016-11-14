using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model.Models
{
    public class Form
    {
        public int FormId { get; set; }

        public string FormName { get; set; }

        public string Email_bcc { get; set; }

        public string Email_cc { get; set; }

        public string Description { get; set; }

        public string ClosingDescription { get; set; }

        public virtual ICollection<FormInfo> FormInfos {get; set;}
}
}
