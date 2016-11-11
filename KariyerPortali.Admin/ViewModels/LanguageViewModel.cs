using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class LanguageViewModel
    {
        public int LanguageId { get; set; }
        [DisplayName("Dil Adı")]
        [Required(ErrorMessage = "Lütfen bir dil adı giriniz.")]
        public string LanguageName { get; set; }
    }
}