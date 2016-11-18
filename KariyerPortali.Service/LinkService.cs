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
    public interface ILinkService
    {

        IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Link> GetLinks();
        Link GetLink(int id);
        void CreateLink(Link link);
        void UpdateLink(Link link);
        void DeleteLink(Link link);
        void SaveLink();

    }
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository linkRepository;
        private readonly IUnitOfWork unitOfWork;
        public LinkService(ILinkRepository linkRepository, IUnitOfWork unitOfWork)
        {
            this.linkRepository = linkRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ILinkService Members
        public IEnumerable<Link> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var links = linkRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return links;
        }
        public IEnumerable<Link> GetLinks()
        {
            var links = linkRepository.GetAll();
            return links;
        }
        public Link GetLink(int id)
        {
            var link = linkRepository.GetById(id);
            return link;
        }
        public void CreateLink(Link link)
        {
            linkRepository.Add(link);
        }
        public void UpdateLink(Link link)
        {
            linkRepository.Update(link);
        }
        public void DeleteLink(Link link)
        {
            linkRepository.Delete(link);
        }
        public void SaveLink()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
