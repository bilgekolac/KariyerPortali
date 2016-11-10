using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class PageViewModel
    {
      
        public int PageId { get; set; }
        
        [DisplayName("Başlık")]
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
         
        [DisplayName("İstatistikler")]
        public int ViewCount { get; set; }

        [DisplayName("Yazar")]
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UptdatedBy { get; set; }
        
        [DisplayName("Tarih")]
        public DateTime UpdateDate { get; set; }
    }
}