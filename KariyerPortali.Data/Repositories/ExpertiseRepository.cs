using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
   
    public class ExpertiseRepository : RepositoryBase<Expertise>, IExpertiseRepository
    {
        public ExpertiseRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface IExpertiseRepository : IRepository<Expertise>
    {
        public IEnumerable<Expertise> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Expertises.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(l => l.ExpertiseName.Contains(sSearch));
                }
            }

            var allExpertises = query;
            IEnumerable<Expertise> filteredExpertises = allExpertises;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredExpertises = filteredExpertises.OrderBy(l => l.ExpertiseId);
                        break;
                    case 2:
                        filteredExpertises = filteredExpertises.OrderBy(l => l.ExpertiseName);
                        break;

                    default:
                        filteredExpertises = filteredExpertises.OrderBy(l => l.ExpertiseId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 1:
                        filteredExpertises = filteredExpertises.OrderByDescending(l => l.ExpertiseId);
                        break;
                    case 2:
                        filteredExpertises = filteredExpertises.OrderByDescending(l => l.ExpertiseName);
                        break;

                    default:
                        filteredExpertises = filteredExpertises.OrderByDescending(l => l.ExpertiseId);
                        break;
                }
            }

            var displayedExpertises = filteredExpertises.Skip(displayStart).Take(displayLength);
            totalRecords = allExpertises.Count();
            totalDisplayRecords = filteredExpertises.Count();
            return displayedExpertises.ToList();
        }
        public interface IExpertiseRepository : IRepository<Expertise>
        {
            IEnumerable<Expertise> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        }

    }
}
