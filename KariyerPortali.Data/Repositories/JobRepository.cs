using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Job> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Jobs.Include("Employer").Include("City").AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    DateTime dDate;
                    bool dateParsed = false;
                    if (DateTime.TryParse(sSearch, out dDate))
                    {
                        dDate = DateTime.Parse(sSearch);
                        dateParsed = true;
                    }
                    query = query.Where(c => c.Title.Contains(sSearch) || c.Description.Contains(sSearch) || c.Employer.EmployerName.Contains(sSearch) || c.City.CityName.Contains(sSearch) || c.JobType.ToString().Contains(sSearch) || (dateParsed == true ? c.Createdate == dDate : false));
                }
            }
            var allJobs = query;

            IEnumerable<Job> filteredJobs = allJobs;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredJobs = filteredJobs.OrderBy(c => c.Title);
                        break;
                    case 1:
                        filteredJobs = filteredJobs.OrderBy(c => c.Description);
                        break;
                    case 2:
                        filteredJobs = filteredJobs.OrderBy(c => c.Employer.EmployerName);
                        break;
                    case 3:
                        filteredJobs = filteredJobs.OrderBy(c => c.City.CityName);
                        break;
                    case 4:
                        filteredJobs = filteredJobs.OrderBy(c => c.JobType);
                        break;
                    case 5:
                        filteredJobs = filteredJobs.OrderBy(c => c.Createdate);
                        break;
                    default:
                        filteredJobs = filteredJobs.OrderBy(c => c.Title);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Title);
                        break;
                    case 1:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Description);
                        break;
                    case 2:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Employer.EmployerName);
                        break;
                    case 3:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.City.CityName);
                        break;
                    case 4:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.JobType);
                        break;
                    case 5:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Createdate);
                        break;
                    default:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Title);
                        break;
                }
            }

            var displayedJobs = filteredJobs.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedJobs = displayedJobs.Take(displayLength);
            }
            totalRecords = allJobs.Count();
            totalDisplayRecords = filteredJobs.Count();
            return displayedJobs.ToList();
        }
        public override void Update(Job entity)
        {

            var job= DbContext.Jobs.Include("SocialRights").Where(c => c.JobId == entity.JobId).Single();
            job.SocialRights.Clear();
            if (entity.SocialRights != null)
            {
                foreach (var socialright in entity.SocialRights)
                {
                    job.SocialRights.Add(socialright);
                }
            }
            job.JobType = entity.JobType;
            job.Qualifications = entity.Qualifications;
            job.Responsibilities = entity.Responsibilities;
            job.Title = entity.Title;
            job.UpdateDate = entity.UpdateDate;
            job.UpdatedBy = entity.UpdatedBy;
            job.CityId = entity.CityId;
            job.EmployerId = entity.EmployerId;
            job.Description = entity.Description;
            job.Createdate = entity.Createdate;
            job.CreatedBy = entity.CreatedBy;
            job.ExperienceId = entity.ExperienceId;
            DbContext.SaveChanges();
        }
    }
    public interface IJobRepository : IRepository<Job>
    {
        IEnumerable<Job> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
    
}
