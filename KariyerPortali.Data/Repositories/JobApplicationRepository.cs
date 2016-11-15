using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{

    public class JobApplicationRepository : RepositoryBase<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<JobApplication> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.JobApplications.Include("Candidate").Include("Employer").Include("Job").AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    //DateTime dDate;
                    //bool dateParsed = false;
                    //if (DateTime.TryParse(sSearch, out dDate))
                    //{
                    //    dDate = DateTime.Parse(sSearch);
                    //    dateParsed = true;
                    //}
                    query = query.Where(j => j.Candidate.FirstName.Contains(sSearch) ||
                   j.Candidate.LastName.Contains(sSearch) || j.Employer.EmployerName.Contains(sSearch) ||
                   j.Job.Title.Contains(sSearch) || /*dateParsed == true ?*/ j.ApplicationDate.ToString().Contains(sSearch) /*== dDate : false*/ ||
                   /*dateParsed == true ?*/ j.UpdateDate.ToString().Contains(sSearch) /*=/*= dDate : false*/
                    );
                }
            }

            var allJobApplications = query;

            IEnumerable<JobApplication> filteredJobApplications = allJobApplications;



            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Candidate.FirstName);
                        break;
                    case 1:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Candidate.LastName);
                        break;
                    case 2:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Employer.EmployerName);
                        break;
                    case 3:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Job.Title);
                        break;

                    case 4:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.ApplicationDate);
                        break;
                    case 5:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.UpdateDate);
                        break;

                    default:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.JobApplicationId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Candidate.FirstName);
                        break;
                    case 1:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Candidate.LastName);
                        break;
                    case 2:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Employer.EmployerName);
                        break;
                    case 3:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Job.Title);
                        break;
                    case 4:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.ApplicationDate);
                        break;
                    case 5:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.UpdateDate);
                        break;

                    default:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.JobApplicationId);
                        break;
                }
            }

            var displayedJobApplications = filteredJobApplications.Skip(displayStart).Take(displayLength);

            totalRecords = allJobApplications.Count();
            totalDisplayRecords = filteredJobApplications.Count();
            return displayedJobApplications.ToList();
        }

    }

    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        IEnumerable<JobApplication> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
