using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class CategoryFormViewModel
    {
        public int CategoryId { get; set; }
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
        [DisplayName("Kısa Ad")]
        public string Slug { get; set; }
        public int? ParentCategoryId { get; set; }        
        public virtual Category ParentCategory { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        
    }
}