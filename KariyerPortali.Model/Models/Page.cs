using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Page
    {
        public int PageId { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }

        public int ViewCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int PageOrder { get; set; }
        public int? ParentPageId { get; set; }
       
        [ForeignKey("ParentPageId")]
        public virtual Page ParentPage { get; set; }
    }
}
