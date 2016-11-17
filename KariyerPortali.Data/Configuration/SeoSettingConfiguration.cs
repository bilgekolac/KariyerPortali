using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class SeoSettingConfiguration : EntityTypeConfiguration<SeoSetting>
    {
        public SeoSettingConfiguration()
        {
            ToTable("SeoSettings");
            HasKey<int>(c => c.SeoSettingId);
            Property(c => c.Description).IsRequired();
            Property(c => c.Keyword).IsRequired();
        }
    }
}
