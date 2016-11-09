using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model.Models
{
    class Page
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string MyProperty { get; set; }
        public float Statistic { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
