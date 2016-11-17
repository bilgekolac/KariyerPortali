using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        
        public string CategoryName { get; set; }
        public string Slug { get; set; }       
        public int? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public int PostCount { get { return Posts.Count(); } }
       
    }
}
