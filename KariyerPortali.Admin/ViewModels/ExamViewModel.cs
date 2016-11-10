using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }
        [DisplayName("Sınav Adı")]
        [Required(ErrorMessage = "Lütfen bir sınav adı giriniz.")]
        public string ExamName { get; set; }
       
    }
}