using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public IEnumerable<Post> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');
            var query = this.DbContext.Posts.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(p => p.PostId.ToString().Contains(sSearch)  || p.Title.Contains(sSearch) || p.Body.Contains(sSearch) || p.CreateDate.ToString().Contains(sSearch) || p.CreatedBy.Contains(sSearch) || p.UpdateDate.ToString().Contains(sSearch) || p.UpdatedBy.Contains(sSearch));
                }
            }
            var allPosts = query;
            IEnumerable<Post> filteredPosts = allPosts;
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 1: filteredPosts = filteredPosts.OrderBy(p => p.PostId);
                        break;
                    case 2: filteredPosts = filteredPosts.OrderBy(p => p.Slug);
                        break;
                    case 3: filteredPosts = filteredPosts.OrderBy(p => p.Title);
                        break;
                    case 4: filteredPosts = filteredPosts.OrderBy(p => p.CreateDate);
                        break;
                    default: filteredPosts = filteredPosts.OrderBy(p => p.PostId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 1: filteredPosts = filteredPosts.OrderByDescending(p => p.PostId);
                        break;
                    case 2: filteredPosts = filteredPosts.OrderByDescending(p => p.Slug);
                        break;
                    case 3: filteredPosts = filteredPosts.OrderByDescending(p => p.Title);
                        break;
                    case 4: filteredPosts = filteredPosts.OrderByDescending(p => p.CreateDate);
                        break;
                    default: filteredPosts = filteredPosts.OrderByDescending(p => p.PostId);
                        break;
                }

            } var displayedPosts = filteredPosts.Skip(displayStart);
            if (displayLength > 0)
            {
                displayedPosts = displayedPosts.Take(displayLength);
            }
            totalRecords = allPosts.Count();
            totalDisplayRecords = filteredPosts.Count();
            return displayedPosts.ToList();
        }
        

    }
    public interface IPostRepository : IRepository<Post>
        {
            IEnumerable<Post> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        }
}
