﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class CountryFormViewModel
    {
        public int CountryId { get; set; }
        
       
        [DisplayName("Ülke Adı")]
        [Required(ErrorMessage = "Lütfen bir ülke adı giriniz.")]
        public string CountryName { get; set; }
     //   public ICollection<City> Cities { get; set; }
    }
}