using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{
    public interface IJobApplicationService
    {
        int GetJobApplicationCountByMonth(int month);
        IEnumerable<JobApplication> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<JobApplication> GetJobApplications();
        JobApplication GetJobApplication(int id);
        void CreateJobApplication(JobApplication jobApplication);
        void UpdateJobApplication(JobApplication jobApplication);
        void DeleteJobApplication(JobApplication jobApplication);
        int CountJobApplication();
        void SaveJobApplication();
    }
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository jobApplicationRepository;
        private readonly IUnitOfWork unitOfWork;
        public JobApplicationService(IJobApplicationRepository jobApplicationRepository, IUnitOfWork unitOfWork)
        {
            this.jobApplicationRepository = jobApplicationRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IJobApplicationService Members

        public IEnumerable<JobApplication> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
         

            var jobapplications = jobApplicationRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return jobapplications;

        }

        public IEnumerable<JobApplication> GetJobApplications()
        {
            var jobApplications = jobApplicationRepository.GetAll();
            return jobApplications;
        }
        public JobApplication GetJobApplication(int id)
        {
            var jobApplication = jobApplicationRepository.GetById(id, "Job", "Employer","Candidate","Sector", "City", "Resume");
            return jobApplication;
        }
        public void CreateJobApplication(JobApplication jobApplication)
        {
            jobApplicationRepository.Add(jobApplication);
        }
        public void UpdateJobApplication(JobApplication jobApplication)
        {
            jobApplicationRepository.Update(jobApplication);
        }
        public void DeleteJobApplication(JobApplication jobApplication)
        {
            jobApplicationRepository.Delete(jobApplication);
        }
        public int CountJobApplication()
        {
            return jobApplicationRepository.GetAll().Count();
        }
        public int GetJobApplicationCountByMonth(int month) 
        {
            return jobApplicationRepository.GetMany(j => j.ApplicationDate.Month == month).Count();
        }
        public void SaveJobApplication()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
