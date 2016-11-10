using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class ResumeRepository : RepositoryBase<Resume>, IResumeRepository
    {
        public ResumeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Resume> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Resumes.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.FirstName.ToString().Contains(sSearch) || c.LastName.ToString().Contains(sSearch));
                }
            }

            var allResumes = query;

            IEnumerable<Resume> filteredResumes = allResumes;


            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredResumes = filteredResumes.OrderBy(c => c.ResumeId);
                        break;
                    case 2:
                        filteredResumes = filteredResumes.OrderBy(c => c.FirstName);
                        break;

                    case 3:
                        filteredResumes = filteredResumes.OrderBy(c => c.LastName);
                        break;
                    case 4:
                        filteredResumes = filteredResumes.OrderBy(c => c.Gender);
                        break;
                    case 5:
                        filteredResumes = filteredResumes.OrderBy(c => c.ComputerSkill);
                        break;
                    case 6:
                        filteredResumes = filteredResumes.OrderBy(c => c.WorkStatus);
                        break;
                    case 7:
                        filteredResumes = filteredResumes.OrderBy(c => c.Notes);
                        break;
                    default:
                        filteredResumes = filteredResumes.OrderBy(c => c.ResumeId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.ResumeId);
                        break;
                    case 2:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.FirstName);
                        break;
                    case 3:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.LastName);
                        break;
                    case 4:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.Gender);
                        break;
                    case 5:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.ComputerSkill);
                        break;
                    case 6:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.WorkStatus);
                        break;
                    case 7:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.Notes);
                        break;
                    default:
                        filteredResumes = filteredResumes.OrderByDescending(c => c.ResumeId);
                        break;
                }
            }

            var displayedResumes = filteredResumes.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedResumes = displayedResumes.Take(displayLength);
            }

            totalRecords = allResumes.Count();
            totalDisplayRecords = filteredResumes.Count();
            return displayedResumes.ToList();
        }
        
    }
    public interface IResumeRepository : IRepository<Resume>
        {
            IEnumerable<Resume> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        }
}