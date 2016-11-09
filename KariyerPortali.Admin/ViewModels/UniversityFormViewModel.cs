using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class UniversityFormViewModel
    {
        public int UniversityId { get; set; }
        [DisplayName("Üniversite Adı")]
        [Required(ErrorMessage = "Lütfen bir üniversite giriniz.")]
        public string UniversityName { get; set; }
    }
}