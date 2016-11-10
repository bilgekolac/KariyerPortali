using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class SkillFormViewModel
    {
        public int SkillId { get; set; }
        [DisplayName("Yetenek Adı")]
        [Required(ErrorMessage = "Lütfen bir yetenek adı giriniz.")]
        public string SkillName { get; set; }
    }
}