using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class ExamInfo
    {
        public int ExamInfoId { get; set; }
      
        public int? ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public float Point { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }
    }
}
