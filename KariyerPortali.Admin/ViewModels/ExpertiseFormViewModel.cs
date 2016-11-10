using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class ExpertiseFormViewModel
    {
        public int ExpertiseId { get; set; }
        [DisplayName("Uzmanlık Adı")]
        public string ExpertiseName { get; set; }
    }
}