using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            /* Fluent-API */
            ToTable("Categories");
            HasKey<int>(c=>c.CategoryId);
            Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            Property(c => c.Slug).IsRequired().HasMaxLength(500);
            Property(c => c.Description);
       //     Property(c => c.ParentName).HasMaxLength(100);
            Property(c => c.Quantity).IsRequired(); 
           
        }
    }
}
