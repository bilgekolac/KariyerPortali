using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class ExperienceConfiguration:EntityTypeConfiguration<Experience>
    {
        public ExperienceConfiguration()
        {
            ToTable("Experiences");
            HasKey<int>(c => c.ExperienceId);
            Property(c => c.Title).IsRequired();
            Property(c => c.Description).IsOptional();
        }
    }
}
