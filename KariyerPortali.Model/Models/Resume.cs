using KariyerPortali.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Resume
    {
        public Resume()
        {
            ViewCount = 0;
        }

        public int ViewCount { get; set; }
        public int ResumeId { get; set; }
        public string ResumeName { get; set; }
        public string Notes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CitizenshipId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CoverLetter { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string CellPhone2 { get; set; }
        public string HomePhone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string HighSchoolName { get; set; }
        public string ComputerSkill { get; set; }
       
        public string ScholarshipAndProject { get; set; }
        public string Hobby { get; set; }
        public string MemberOwnedCommunity { get; set; }
        public bool DrivingLicenseExists { get; set; }
        public DateTime HighSchoolStart { get; set; }
        public DateTime HighSchoolEnd { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MilitaryPostponeDate { get; set; }

       
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

       
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual Gender Gender { get; set; }

        
        public int? BirthCityId { get; set; }
        [ForeignKey("BirthCityId")]
        public virtual City BirthCity { get; set; }

        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual WorkStatus WorkStatus { get; set; }
        
        public int? CountryId { get; set; }
        public virtual Country Nationality { get; set; }

        public virtual MilitaryService MilitaryService { get; set; }

        public virtual DrivingLicenseClass DrivingLicense1Class { get; set; }
        public DateTime? DrivingLicense1Date { get; set; }

        public virtual DrivingLicenseClass DrivingLicense2Class { get; set; }
        public DateTime? DrivingLicense2Date { get; set; }

        public int? HighSchoolTypeId { get; set; }
        public virtual HighSchoolType HighSchoolType { get; set; }

        public int? HighSchoolDepartmentId { get; set; }
        public virtual HighSchoolDepartment HighSchoolDepartment { get; set; }

        public virtual HighSchoolCertificate HighSchoolCertificate { get; set; }
        public float CertificateDegree { get; set; }

        public virtual BloodType BloodType { get; set; }
        public virtual CigaretteStatus CigaretteStatus { get; set; }
        public virtual SalaryWaited SalaryWaited { get; set; }
        public virtual ICollection<Certificate> CertificateInfos { get; set; }
        public virtual ICollection<LanguageInfo> LanguageInfos { get; set; }
        public virtual ICollection<ExamInfo> ExamInfos { get; set; }
        public virtual ICollection<SkillInfo> SkillInfos { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Reference> References { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<EducationInfo> EducationInfos { get; set; }
    }
}
