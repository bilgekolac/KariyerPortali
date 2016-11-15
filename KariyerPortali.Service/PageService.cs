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
    public interface IPageService
    {
        IEnumerable<Page> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Page> GetPages();
        Page GetPage(int id);
        void CreatePage(Page Page);
        void UpdatePage(Page Page);
        void DeletePage(Page Page);
        void SavePage();
    }
    public class PageService : IPageService
    {
       private readonly IPageRepository PageRepository;
        private readonly IUnitOfWork unitOfWork;
        public PageService(IPageRepository PageRepository, IUnitOfWork unitOfWork)
        {
            this.PageRepository = PageRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IPageService Members
        public IEnumerable<Page> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var pages = PageRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return pages;
        }
        public IEnumerable<Page> GetPages()
        {
            var pages = PageRepository.GetAll();
            return pages;
        }
        public Page GetPage(int id)
        {
            var Page = PageRepository.GetById(id);
            return Page;
        }
        public void CreatePage(Page Page)
        {
            PageRepository.Add(Page);
        }
        public void UpdatePage(Page Page)
        {
           PageRepository.Update(Page);
        }
        public void DeletePage(Page Page)
        {
            PageRepository.Delete(Page);
        }
        public void SavePage()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
