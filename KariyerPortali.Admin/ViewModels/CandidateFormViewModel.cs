using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class CandidateFormViewModel
    {
        public int CandidateId { get; set; }
        [Required(ErrorMessage = "Aday kullanıcı adı gereklidir.")]
        [DisplayName("Kullanıcı Adı :")]
        public string UserName { get; set; }
        [DisplayName("Aday Adı :")]
        public string FirstName { get; set; }
        [DisplayName("Aday Soyadı :")]
        public string LastName { get; set; }
        [DisplayName("Eposta :")]
        public string Email { get; set; }
        [DisplayName("Telefon No :")]
        public string Phone { get; set; }
        [DisplayName("Doğum Tarihi :")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Fotoğraf :")]
        public string Photo { get; set; }
        [DisplayName("Oluşturulma Tarihi:")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Durum :")]
        public bool State { get; set; }
        [DisplayName("Güncelleyen :")]
        public string UpdatedBy { get; set; }
        [DisplayName("Güncelleme Tarihi:")]
        public DateTime UpdatedDate { get; set; }
    }
}
