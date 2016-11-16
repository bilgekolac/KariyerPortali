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
    public interface IRedirectService
    {
        IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Redirect> GetRedirects();
        Redirect GetRedirect(int id);
        void CreateRedirect(Redirect redirect);
        void UpdateRedirect(Redirect redirect);
        void DeleteRedirect(Redirect redirect);
        int CountRedirect();
        void SaveRedirect();
    }
    public class RedirectService : IRedirectService
    {
        private readonly IRedirectRepository redirectRepository;
        private readonly IUnitOfWork unitOfWork;
        public RedirectService(IRedirectRepository redirectRepository, IUnitOfWork unitOfWork)
        {
            this.redirectRepository = redirectRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IRedirectService Members
        public IEnumerable<Redirect> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var redirects = redirectRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return redirects;
        }

        public IEnumerable<Redirect> GetRedirects()
        {
            var redirects = redirectRepository.GetAll();
            return redirects;
        }
        public Redirect GetRedirect(int id)
        {
            var redirect = redirectRepository.GetById(id);
            return redirect;
        }
        public void CreateRedirect(Redirect redirect)
        {
            redirectRepository.Add(redirect);
        }
        public void UpdateRedirect(Redirect redirect)
        {
            redirectRepository.Update(redirect);
        }
        public void DeleteRedirect(Redirect redirect)
        {
            redirectRepository.Delete(redirect);
        }
        public void SaveRedirect()
        {
            unitOfWork.Commit();
        }
        public int CountRedirect()
        {
            return redirectRepository.GetAll().Count();
        }

        #endregion
    }
}
