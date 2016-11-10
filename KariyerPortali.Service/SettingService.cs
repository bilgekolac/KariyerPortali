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
    public interface ISettingService
    {
        IEnumerable<Setting> GetSettings();
        Setting GetSetting(int id);
        void CreateSetting(Setting setting);
        void UpdateSetting(Setting setting);
        void DeleteSetting(Setting setting);
        void SaveSetting();
    }
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository settingRepository;
        private readonly IUnitOfWork unitOfWork;
        public SettingService(ISettingRepository settingRepository, IUnitOfWork unitOfWork)
        {
            this.settingRepository = settingRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISettingService Members
        // public IEnumerable<Setting> GetSettingByName()
        //{
        //    var settings = settingRepository.GetSettingByName();

        //    return settings;
        public IEnumerable<Setting> GetSettings()
        {
            var settings = settingRepository.GetAll();
            return settings;
        }
        public Setting GetSetting(int id)
        {
            var setting = settingRepository.GetById(id);
            return setting;
        }
        public void CreateSetting(Setting setting)
        {
            settingRepository.Add(setting);
        }
        public void UpdateSetting(Setting setting)
        {
            settingRepository.Update(setting);
        }
        public void DeleteSetting(Setting setting)
        {
            settingRepository.Delete(setting);
        }
        public void SaveSetting()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
