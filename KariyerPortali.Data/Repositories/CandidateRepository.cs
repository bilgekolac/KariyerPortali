using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Candidate> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)

        {
            search = search.Trim();
            var searchWords = search.Split(' ');

            var query = this.DbContext.Candidates.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.UserName.Contains(sSearch) || c.FirstName.Contains(sSearch) || c.LastName.Contains(sSearch) || c.Photo.Contains(sSearch));
                }
            }

            var allCandidates = query;



            IEnumerable<Candidate> filteredCandidates = allCandidates;



            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.UserName);
                        break;
                    case 1:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.FirstName);
                        break;
                    case 2:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.LastName);
                        break;
                    case 3:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.Phone);
                        break;
                    case 4:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.Email);
                        break;
                    case 5:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.State);
                        break;
                    case 6:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.CreateDate);
                        break;
                    default:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.UserName);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.UserName);
                        break;
                    case 1:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.FirstName);
                        break;
                    case 2:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.LastName);
                        break;
                    case 3:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.Phone);
                        break;
                    case 4:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.Email);
                        break;
                    case 5:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.State);
                        break;
                    case 6:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.CreateDate);
                        break;
                    default:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.UserName);
                        break;
                }
            }
            var displayedCandidates = filteredCandidates.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedCandidates = displayedCandidates.Take(displayLength);
            }
            totalRecords = allCandidates.Count();
            totalDisplayRecords = filteredCandidates.Count();
            return displayedCandidates.ToList();
        }
    }

        public interface ICandidateRepository : IRepository<Candidate>
        {
            IEnumerable<Candidate> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        }
    }

    
