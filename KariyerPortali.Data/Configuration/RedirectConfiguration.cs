using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class RedirectConfiguration: EntityTypeConfiguration<Redirect>
    {
        public RedirectConfiguration()
        {
            ToTable("Redirects");
            HasKey<int>(c => c.RedirectId);
            Property(c => c.RedirectName).IsRequired().HasMaxLength(200);
            Property(c => c.OldUrl).IsRequired().HasMaxLength(100);
            Property(c => c.OldUrl).IsRequired().HasMaxLength(100);
        }
    }
}
