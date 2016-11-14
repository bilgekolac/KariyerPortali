using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class PageFormViewModel
    {
        public int PageId { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Kısa Ad")]
        public string Slug { get; set; }
        
        [DisplayName("İçerik")]
        public string Body { get; set; }

        [DisplayName("İstatistikler")]
        public int ViewCount { get; set; }

        [DisplayName("Yazar")]
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }

        [DisplayName("Tarih")]
        public DateTime UpdateDate { get; set; }
    }
}