using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }


        [DisplayName("Ülke Adı")]
        public string CountryName { get; set; }
    }
}