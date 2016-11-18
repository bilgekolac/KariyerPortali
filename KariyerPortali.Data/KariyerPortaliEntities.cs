using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KariyerPortali.Model;
using KariyerPortali.Data.Configuration;

namespace KariyerPortali.Data
{
    public class KariyerPortaliEntities : DbContext
    {
        public KariyerPortaliEntities() : base("KariyerPortaliEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KariyerPortaliEntities, KariyerPortali.Data.Migrations.Configuration>("KariyerPortaliEntities"));
        }

        public DbSet<Certificate>Certificates { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationInfo> EducationInfos { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamInfo> ExamInfos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<HighSchoolDepartment> HighSchollDepartments { get; set; }
        public DbSet<HighSchoolType> HighSchollTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageInfo> LanguageInfos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillInfo> SkillInfos { get; set; }
        public DbSet<SocialRight> SocialRights { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormInfo> FormInfos { get; set; }
        public DbSet<Redirect> Redirects { get; set; }
        public DbSet<SeoSetting> SeoSettings { get; set; }
        public DbSet<Link> Links { get; set; }

        public virtual void Commit()
        {
            try {                 
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CandidateConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new EducationInfoConfiguration());
            modelBuilder.Configurations.Add(new EmployerConfiguration());
            modelBuilder.Configurations.Add(new ExamConfiguration());
            modelBuilder.Configurations.Add(new ExamInfoConfiguration());
            modelBuilder.Configurations.Add(new ExperienceConfiguration());
            modelBuilder.Configurations.Add(new ExpertiseConfiguration());
            modelBuilder.Configurations.Add(new FileConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
            modelBuilder.Configurations.Add(new JobApplicationConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new LanguageInfoConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new ReferenceConfiguration());
            modelBuilder.Configurations.Add(new ResumeConfiguration());
            modelBuilder.Configurations.Add(new SectorConfiguration());
            modelBuilder.Configurations.Add(new SkillConfiguration());
            modelBuilder.Configurations.Add(new SkillInfoConfiguration());
            modelBuilder.Configurations.Add(new SocialRightConfiguration());
            modelBuilder.Configurations.Add(new UniversityConfiguration());
            modelBuilder.Configurations.Add(new PageConfiguration());
            modelBuilder.Configurations.Add(new SettingConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new FormConfiguration());
            modelBuilder.Configurations.Add(new FormInfoConfiguration());
            modelBuilder.Configurations.Add(new RedirectConfiguration());
            modelBuilder.Configurations.Add(new SeoSettingConfiguration());
        }
    }
}
