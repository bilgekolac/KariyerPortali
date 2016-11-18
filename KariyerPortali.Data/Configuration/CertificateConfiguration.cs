using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    class CertificateConfiguration : EntityTypeConfiguration<Certificate>
    {
        public CertificateConfiguration()
        {
            ToTable("Certificates");
            HasKey<int>(c => c.CertificateId);
           

        }

    }
}
