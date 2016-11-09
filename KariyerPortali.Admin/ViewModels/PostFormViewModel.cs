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
        [DisplayName("Başlık Adı")]
        [Required(ErrorMessage = "Lütfen yazınıza bir başlık giriniz.")]
        public string Title { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage="Lütfen yazı giriniz.")]
        public string Body { get; set; }
    }
}