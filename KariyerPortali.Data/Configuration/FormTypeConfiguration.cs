using KariyerPortali.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class FormTypeConfiguration:EntityTypeConfiguration<FormType>
    {
        public FormTypeConfiguration()
        {
            ToTable("FormTypes");
            HasKey<int>(c => c.FormTypeId);
            Property(c => c.FormTypeName).IsRequired();
        }
    }
}
