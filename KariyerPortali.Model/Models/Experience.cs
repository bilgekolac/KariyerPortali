using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
