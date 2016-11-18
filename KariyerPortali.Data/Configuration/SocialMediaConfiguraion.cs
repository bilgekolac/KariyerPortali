using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class SocialMediaConfiguraion:EntityTypeConfiguration<SocialMedia>
    {
    
    
        public SocialMediaConfiguraion()
        {
            ToTable("SociakMedias");
            HasKey<int>(c => c.SocialMediaId);
            Property(c => c.FaceAddress).IsRequired().HasMaxLength(100);
            Property(c => c.TwitterAddress).IsRequired().HasMaxLength(100);
            Property(c=> c.InstagramAddress).IsRequired().HasMaxLength(100);
            Property(c => c.LinkedinAddress).IsRequired().HasMaxLength(100);
        }
    }
}
