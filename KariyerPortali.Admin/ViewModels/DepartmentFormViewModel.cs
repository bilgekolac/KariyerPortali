using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class DepartmentFormViewModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Bölüm adı gereklidir.")]
        [DisplayName("Bölüm Adı")]
        public string DepartmentName { get; set; }
    }
}