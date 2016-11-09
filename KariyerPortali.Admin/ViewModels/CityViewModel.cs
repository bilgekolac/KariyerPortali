using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
	public class CityViewModel
	{
        public int CityId { get; set; }
         [DisplayName("Şehir")]
        public string CityName { get; set; }
            
        public int CountryId { get; set; }
      
        public Country Country { get; set; }

    }
}