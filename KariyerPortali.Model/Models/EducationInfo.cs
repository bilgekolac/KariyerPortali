using System.Collections.Generic;
namespace KariyerPortali.Model
{
    public class EducationInfo
    {
        public int EducationInfoId { get; set; }
        public virtual EducationStatus EducationStatus { get; set; }

        public int? UniversityId { get; set; }
        public virtual University University { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }

    }
}