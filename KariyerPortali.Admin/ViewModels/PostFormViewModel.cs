using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class PostFormViewModel
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Lütfen yazınıza bir başlık giriniz.")]
        [DisplayName("Başlık Adı")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen yazı giriniz.")]
        [DisplayName("İçerik")]
        public string Body { get; set; }
    }
}