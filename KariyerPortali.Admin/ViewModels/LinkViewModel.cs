using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class LinkViewModel
    {
        public int LinkId { get; set; }
        [DisplayName("Link Adı")]
        [Required(ErrorMessage = "Lütfen bir link adı giriniz.")]
        public string LinkName { get; set; }
        [DisplayName("URL")]
        [Required(ErrorMessage = "Lütfen bir url giriniz.")]
        public string Url { get; set; }
        [DisplayName("Görünür")]
        public bool Visible { get; set; }
    }
}