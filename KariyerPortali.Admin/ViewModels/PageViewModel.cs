using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.ViewModels
{
    public class PageViewModel
    {

        public int PageId { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }
        
        [DisplayName("Kısa Ad")]
        public string Slug { get; set; }
        
        [DisplayName("İçerik")]
        [AllowHtml]
        public string Body { get; set; }

        [DisplayName("İstatistikler")]
        public int ViewCount { get; set; }

        [DisplayName("Yazar")]
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }

        [DisplayName("Tarih")]
        public DateTime UpdateDate { get; set; }

        [DisplayName("Sıralama")]
        public int PageOrder { get; set; }

        [DisplayName("Üst Sayfa")]
        public int? ParentPageId { get; set; }

        [ForeignKey("ParentPageId")]
        public virtual Page ParentPage { get; set; }
    }
}