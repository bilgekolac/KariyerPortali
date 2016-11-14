using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public float Time { get; set; }
        public string Statement { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }

    }
}
