using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class FormConfiguration:EntityTypeConfiguration<Form>
    {
        public FormConfiguration()
        {
            ToTable("Forms");
            HasKey<int>(c => c.FormId);
            Property(c => c.Description).IsRequired();
            Property(c => c.FormName).IsRequired();
        }

    }
}
