using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Exam> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Exams.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(e => e.ExamName.Contains(sSearch));
                }
            }

            var allExams = query;

            IEnumerable<Exam> filteredExams = allExams;

            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredExams = filteredExams.OrderBy(e => e.ExamId);
                        break;
                    case 2:
                        filteredExams = filteredExams.OrderBy(e => e.ExamName);
                        break;

                    default:
                        filteredExams = filteredExams.OrderBy(e => e.ExamId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1:
                        filteredExams = filteredExams.OrderByDescending(e => e.ExamId);
                        break;
                    case 2:
                        filteredExams = filteredExams.OrderByDescending(e => e.ExamName);
                        break;

                    default:
                        filteredExams = filteredExams.OrderByDescending(e => e.ExamId);
                        break;
                }
            }
            var displayedExams = filteredExams.Skip(displayStart);
            if (displayLength >= 0)
            {
                displayedExams = displayedExams.Take(displayLength);
            }
            totalRecords = allExams.Count();
            totalDisplayRecords = filteredExams.Count();
            return displayedExams.ToList();

        }
    }
    public interface IExamRepository : IRepository<Exam>
    {
        IEnumerable<Exam> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
    }
}
