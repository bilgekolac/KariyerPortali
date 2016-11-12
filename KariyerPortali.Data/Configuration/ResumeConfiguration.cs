using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace KariyerPortali.Data.Configuration
{
    public class ResumeConfiguration: EntityTypeConfiguration<Resume>
    {
        public ResumeConfiguration()
        {
            ToTable("Resumes");
            HasKey<int>(c => c.ResumeId);
            Property(c => c.ViewCount).IsRequired();
            Property(c => c.ResumeName).IsRequired().HasMaxLength(200);
            Property(c => c.FirstName).IsRequired().HasMaxLength(200);
            Property(c => c.LastName).IsRequired().HasMaxLength(200);
            Property(c => c.WorkStatus).IsRequired();
            Property(c => c.Notes).IsOptional().HasMaxLength(200);
            Property(c => c.Gender).IsRequired();
            Property(c => c.CreateDate).IsRequired();
            Property(c => c.CreatedBy).IsRequired().HasMaxLength(200);
            Property(c => c.UpdateDate).IsRequired();
            Property(c => c.UpdatedBy).IsRequired().HasMaxLength(200);
            Property(c => c.DrivingLicenseExists).IsRequired();
            Property(c => c.CoverLetter).IsRequired().HasMaxLength(200);
            Property(c => c.Email).IsRequired().HasMaxLength(200);
            Property(c => c.CellPhone).IsRequired().HasMaxLength(14);
            Property(c => c.CellPhone2).HasMaxLength(14);
            Property(c => c.HomePhone).HasMaxLength(14);
            Property(c => c.Website).HasMaxLength(200);
            Property(c => c.Address).IsRequired().HasMaxLength(200);
            Property(c => c.HighSchoolName).HasMaxLength(200);
            Property(c => c.HighSchoolStart).IsRequired();
            Property(c => c.HighSchoolEnd).IsRequired();
            Property(c => c.CertificateDegree).IsOptional();
            Property(c => c.ComputerSkill).IsOptional().HasMaxLength(200);
            Property(c => c.Certificate).IsOptional().HasMaxLength(200);
            Property(c => c.ScholarshipAndProject).IsOptional().HasMaxLength(200);
            Property(c => c.Hobby).IsOptional();
            Property(c => c.MemberOwnedCommunity).IsOptional().HasMaxLength(200);
            Property(c => c.MilitaryPostponeDate).IsRequired();

           





        }
    }
}
