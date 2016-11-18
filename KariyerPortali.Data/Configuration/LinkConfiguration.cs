using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class LinkConfiguration : EntityTypeConfiguration<Link>
    {
        public LinkConfiguration()
        {
            /* Fluent-API */
            ToTable("Links");
            HasKey<int>(l => l.LinkId);
            Property(l => l.LinkName).IsRequired().HasMaxLength(100);
            Property(l => l.Url).IsRequired().HasMaxLength(500);
            Property(l => l.Visible);
            Property(l => l.Definition);
            Property(l => l.Target);



        }
    }
}
