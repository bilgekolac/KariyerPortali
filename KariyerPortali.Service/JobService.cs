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
    public interface IJobService
    {
        IEnumerable<Job> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Job> GetJobs();
        Job GetJob(int id);
        void CreateJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(Job job);
        void SaveJob();
        
    }
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IUnitOfWork unitOfWork;
        public JobService(IJobRepository jobRepository, IUnitOfWork unitOfWork)
        {
            this.jobRepository = jobRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IJobService Members
        public IEnumerable<Job> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var jobs = jobRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return jobs;
        }
        public IEnumerable<Job> GetJobs()
        {
            var jobs = jobRepository.GetAll("Employer");
            return jobs;
        }
        public Job GetJob(int id)
        {
            var job = jobRepository.GetById(id);
            return job;
        }
        public void CreateJob(Job job)
        {
            jobRepository.Add(job);
        }
        public void UpdateJob(Job job)
        {
            jobRepository.Update(job);
        }
        public void DeleteJob(Job job)
        {
            jobRepository.Delete(job);
        }
        public void SaveJob()
        {
            unitOfWork.Commit();
        }
        
        #endregion
    }
}
