using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class LinkConfiguration: EntityTypeConfiguration<Link>
    {
         public LinkConfiguration()
        {
            /* Fluent-API */
            ToTable("Links");
            HasKey<int>(c => c.LinkId);
            Property(c => c.LinkName).IsRequired().HasMaxLength(100);
            Property(c => c.Url).IsRequired().HasMaxLength(500);
            Property(c => c.Visible).IsRequired();
       
           
           
        }
    }
}
