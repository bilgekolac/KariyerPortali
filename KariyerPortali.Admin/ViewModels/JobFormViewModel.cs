using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class JobFormViewModel
    {
        public int JobId { get; set; }

        [Required(ErrorMessage = "İş adı gereklidir.")]
        [DisplayName("İş Adı")]
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayName("Firma Adı")]
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        [DisplayName("Lokasyon")]
        public int CityId { get; set; }
        public City City { get; set; }

        [DisplayName("Çalışma Şekli")]
        public JobType JobType { get; set; }

        [DisplayName("İş Tecrübesi")]
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }

        [DisplayName("Sorumluluklar")]
        public string Responsibilities { get; set; }

        [DisplayName("Vasıflar")]
        public string Qualifications { get; set; }
        public DateTime Createdate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}