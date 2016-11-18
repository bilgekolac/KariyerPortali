using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class SeoSettingFormViewModel
    {
        public int SeoSettingId { get; set; }
        [Required(ErrorMessage = "Başlık gereklidir.")]
        [DisplayName("Başlık :")]
        public string Title { get; set; }
        [DisplayName("Tanım :")]
        [Required(ErrorMessage = "Tanım gereklidir.")]
        public string Description { get; set; }
        [DisplayName("Anahtar Kelimeler :")]
        [Required(ErrorMessage = "Anahtar Kelimeler gereklidir.")]
        public string Keyword { get; set; }


    }
}