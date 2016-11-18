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
    //public interface ISeoSettingService
    //{
    //    SeoSetting GetSettingByName(string name);
    //    IEnumerable<SeoSetting> GetSettings();
    //    SeoSetting GetSetting(int id);
    //    void CreateSetting(SeoSetting seoSetting);
    //    void UpdateSetting(SeoSetting seoSetting);
    //    void DeleteSetting(SeoSetting seoSetting);
    //    void SaveSetting();
    //}
    //public class SeoSettingService : ISeoSettingService
    //{
    //    private readonly ISeoSettingRepository seoSettingRepository;
    //    private readonly IUnitOfWork unitOfWork;
    //    public SeoSettingService(ISeoSettingRepository seoSettingRepository, IUnitOfWork unitOfWork)
    //    {
    //        this.seoSettingRepository = seoSettingRepository;
    //        this.unitOfWork = unitOfWork;
    //    }
    //    #region ISeoSettingService Members
    //    public SeoSetting GetSettingByName(string name)
    //    {
    //        var seoSettings = seoSettingRepository.GetSettingByName(name);
    //        return seoSettings;
    //    }
    //    public IEnumerable<SeoSetting> GetSettings()
    //    {
    //        var seoSettings = seoSettingRepository.GetAll();
    //        return seoSettings;
    //    }
    //    public SeoSetting GetSetting(int id)
    //    {
    //        var seoSetting = seoSettingRepository.GetById(id);
    //        return seoSetting;
    //    }
    //    public void CreateSetting(SeoSetting seoSetting)
    //    {
    //        seoSettingRepository.Add(seoSetting);
    //    }
    //    public void UpdateSetting(SeoSetting seoSetting)
    //    {
    //        seoSettingRepository.Update(seoSetting);
    //    }
    //    public void DeleteSetting(SeoSetting seoSetting)
    //    {
    //        seoSettingRepository.Delete(seoSetting);
    //    }
    //    public void SaveSetting()
    //    {
    //        unitOfWork.Commit();
    //    }
    //    #endregion
    //}
}
