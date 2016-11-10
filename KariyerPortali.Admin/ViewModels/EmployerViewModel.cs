using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class EmployerViewModel
    {
        public int EmployerId { get; set; }
        public string Logo { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "İşveren adı gereklidir.")]
        [DisplayName("İşveren Adı")]
        public string EmployerName { get; set; }

        [DisplayName("Sektör")]
        public int SectorId { get; set; }
        public Sector Sector { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "Adres bilgisi gereklidir.")]
        public string Address { get; set; }

        [DisplayName("Şehir")]
        public int CityId { get; set; }
        public City City { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Telefon bilgisi gereklidir.")]
        public string Phone { get; set; }

        [DisplayName("E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail bilgisi gereklidir.")]
        public string Email { get; set; }

        [DisplayName("Web Site")]
        [Required(ErrorMessage = "Website bilgisi gereklidir.")]
        public string WebSite { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Oluşturan Kişi")]
        public string CreatedBy { get; set; }
        [DisplayName("Güncellenme Tarihi")]
        public DateTime UpdateDate { get; set; }
        [DisplayName("Güncelleyen Kişi")]
        public string UpdatedBy { get; set; }
    }
}