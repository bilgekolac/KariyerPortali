using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class CategoryFormViewModel
    {
        public int CategoryId { get; set; }
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "Lütfen bir kategori adı giriniz.")]
        public string CategoryName { get; set; }
        [DisplayName("Kısa Ad")]
        [Required(ErrorMessage = "Lütfen bir kısa ad giriniz.")]
        public string Slug { get; set; }
        [DisplayName("Veli")]
        public int? ParentCategoryId { get; set; }        
        public virtual Category ParentCategory { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }

    }
}