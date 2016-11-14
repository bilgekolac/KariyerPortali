using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class LanguageInfo
    {
        public int LanguageInfoId { get; set; }
       
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual LanguageLevel WritingLanguageLevel { get; set; }
        public virtual LanguageLevel ReadingLanguageLevel { get; set; }
        public virtual LanguageLevel SpeakingLanguageLevel { get; set; }
    }
}
