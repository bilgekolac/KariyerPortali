using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class RedirectFormViewModel
    {
        public int RedirectId { get; set; }
        [Required(ErrorMessage = "Yönlendirme adı gereklidir.")]
        [DisplayName("Yönlendirme Adı :")]
        public string RedirectName { get; set; }
        [DisplayName("Eski Adres :")]
        public string OldUrl { get; set; }
        [DisplayName("Yeni Adres :")]
        public string NewUrl { get; set; }
        [DisplayName("Bağlantı Türü:")]
        public virtual RedirectType RedirectType { get; set; }

    }
}