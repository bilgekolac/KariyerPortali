using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class ExpertiseViewModel
    {
        public int ExpertiseId { get; set; }
        [DisplayName("Uzmanlık Adı")]
        [Required(ErrorMessage = "Lütfen bir uzmanlık adı giriniz.")]
        public string ExpertiseName { get; set; }
    }
}