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
    public interface IPostService
    {
        IEnumerable<Post> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Post> GetPosts();
        Post GetPost(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        void SavePost();
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IUnitOfWork unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IPostService Members
        public IEnumerable<Post> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var posts = postRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return posts;
        }
        public IEnumerable<Post> GetPosts()
        {
            var posts = postRepository.GetAll();
            return posts;
        }
        public Post GetPost(int id)
        {
            var post = postRepository.GetById(id);
            return post;
        }
        public void CreatePost(Post post)
        {
            postRepository.Add(post);
        }
        public void UpdatePost(Post post)
        {
            postRepository.Update(post);
        }
        public void DeletePost(Post post)
        {
            postRepository.Delete(post);
        }
        public void SavePost()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
