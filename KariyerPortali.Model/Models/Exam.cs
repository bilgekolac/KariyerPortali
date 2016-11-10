using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
       
        public virtual ICollection<ExamInfo> ExamInfos { get; set; }
    }
}
