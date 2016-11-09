using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class CityFormViewModel
    {
        public int CityId { get; set; }
         [DisplayName("Şehir")]
        public string CityName { get; set; }
        [DisplayName("Ülke")]
        public int CountryId { get; set; }
        //public Country Country { get; set; }
    }
}