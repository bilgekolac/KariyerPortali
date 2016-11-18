using KariyerPortali.Model;
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
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime ExperienceStart { get; set; }
        public DateTime ExperienceEnd { get; set; }

        public virtual ExperienceStatus ExperienceStatus { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
