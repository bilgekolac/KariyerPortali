using KariyerPortali.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class FormInfoConfiguration:EntityTypeConfiguration<FormInfo>
    {
        public FormInfoConfiguration()
        {
            ToTable("FormInfos");
            HasKey<int>(c => c.FormInfoId);
            Property(c => c.FormInfoDescription).IsRequired();

        }
    }
}
