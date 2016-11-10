using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class ExamConfiguration:EntityTypeConfiguration<Exam>
    {
        public ExamConfiguration()
        {
            ToTable("Exams");
            HasKey<int>(c => c.ExamId);
            Property(c => c.ExamName).IsRequired().HasMaxLength(50);
           
        }
    }
}
