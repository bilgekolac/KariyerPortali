using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class SectorFormViewModel
    {
        public int SectorId { get; set; }
        [DisplayName("Sektör Adı")]
        [Required(ErrorMessage = "Lütfen bir sektör adı giriniz.")]
        public string SectorName { get; set; }
    }
}