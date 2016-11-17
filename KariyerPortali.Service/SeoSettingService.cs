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
    public interface ISeoSettingService
    {
        IEnumerable<SeoSetting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<SeoSetting> GetSeoSettings();
        SeoSetting GetSeoSetting(int id);
        void CreateSeoSetting(SeoSetting seoSetting);
        void UpdateSeoSetting(SeoSetting seoSetting);
        void DeleteSeoSetting(SeoSetting seoSetting);
        int CountSeoSetting();
        void SaveSeoSetting();
    }
    public class SeoSettingService : ISeoSettingService
    {
        private readonly ISeoSettingRepository SeoSettingRepository;
        private readonly IUnitOfWork unitOfWork;
        public SeoSettingService(ISeoSettingRepository SeoSettingRepository, IUnitOfWork unitOfWork)
        {
            this.SeoSettingRepository = SeoSettingRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISeoSettingService Members
        public IEnumerable<SeoSetting> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var seoSettings = SeoSettingRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return seoSettings;
        }

        public IEnumerable<SeoSetting> GetSeoSettings()
        {
            var seoSettings = SeoSettingRepository.GetAll();
            return seoSettings;
        }
        public SeoSetting GetSeoSetting(int id)
        {
            var seoSetting = SeoSettingRepository.GetById(id);
            return seoSetting;
        }
        public void CreateSeoSetting(SeoSetting seoSetting)
        {
            SeoSettingRepository.Add(seoSetting);
        }
        public void UpdateSeoSetting(SeoSetting seoSetting)
        {
            SeoSettingRepository.Update(seoSetting);
        }
        public void DeleteSeoSetting(SeoSetting seoSetting)
        {
            SeoSettingRepository.Delete(seoSetting);
        }
        public void SaveSeoSetting()
        {
            unitOfWork.Commit();
        }
        public int CountSeoSetting()
        {
            return SeoSettingRepository.GetAll().Count();
        }

        #endregion
    }
}
