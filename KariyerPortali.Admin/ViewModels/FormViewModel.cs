using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class FormViewModel
    {
        public int FormId { get; set; }

        public string FormName { get; set; }

        public string Email_bcc { get; set; }

        public string Email_cc { get; set; }

        public string Description { get; set; }

        public string ClosingDescription { get; set; }

        public List<int> FormInfoId { get; set; }
    }
}