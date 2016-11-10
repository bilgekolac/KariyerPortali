using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class PageConfiguration:EntityTypeConfiguration<Page>
    {
        public PageConfiguration()
        {
            ToTable("Table");
            HasKey<int>(p=>p.PageId);
            Property(p => p.Title).IsRequired().HasMaxLength(100);

        }
    }
}
