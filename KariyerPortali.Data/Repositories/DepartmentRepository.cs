using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
   
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Department> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Departments.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.DepartmentName.Contains(sSearch) );
                }
            }

            var allDepartments = query;

            IEnumerable<Department> filteredDepartments = allDepartments;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredDepartments = filteredDepartments.OrderBy(c => c.DepartmentId);
                        break;
                    case 2:
                        filteredDepartments = filteredDepartments.OrderBy(c => c.DepartmentName);
                        break;
                    default:
                        filteredDepartments = filteredDepartments.OrderBy(c => c.DepartmentId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredDepartments = filteredDepartments.OrderByDescending(c => c.DepartmentId);
                        break;
                    case 2:
                        filteredDepartments = filteredDepartments.OrderByDescending(c => c.DepartmentName);
                        break;
                    default:
                        filteredDepartments = filteredDepartments.OrderByDescending(c => c.DepartmentId);
                        break;
                }
            }

            var displayedDepartments = filteredDepartments.Skip(displayStart).Take(displayLength);

            totalRecords = allDepartments.Count();
            totalDisplayRecords = filteredDepartments.Count();
            return displayedDepartments.ToList();
        }
    }
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
