using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.ViewModels
{
    public class FormFormViewModel
    {
        public int FormId { get; set; }

        public string FormName { get; set; }

        public string Email_bcc { get; set; }

        public string Email_cc { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string ClosingDescription { get; set; }

        public List<int> FormInfoId { get; set; }
    }
}