using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public string ParentName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
       
    }
}
