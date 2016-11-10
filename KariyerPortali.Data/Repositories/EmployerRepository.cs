using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class EmployerRepository : RepositoryBase<Employer>, IEmployerRepository
    {
        public EmployerRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Employer> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Employers.Include("City").AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.EmployerName.Contains(sSearch) || c.City.CityName.Contains(sSearch) || c.Email.Contains(sSearch));
                }
            }

            var allEmployers = query;

            IEnumerable<Employer> filteredEmployers = allEmployers;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.Logo);
                        break;
                    case 1:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.EmployerName);
                        break;
                    case 2:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.City.CityName);
                        break;
                    case 3:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.Email);
                        break;

                    default:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.EmployerName);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.Logo);
                        break;
                    case 1:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.EmployerName);
                        break;
                    case 2:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.City.CityName);
                        break;
                    case 3:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.Email);
                        break;

                    default:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.EmployerName);
                        break;
                }
            }

            var displayedEmployers = filteredEmployers.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedEmployers = displayedEmployers.Take(displayLength);
            }

            totalRecords = allEmployers.Count();
            totalDisplayRecords = filteredEmployers.Count();
            return displayedEmployers.ToList();
        }
    }
    public interface IEmployerRepository : IRepository<Employer>
    {
        IEnumerable<Employer> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
