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
    public interface IFormInfoService
    {
        IEnumerable<FormInfo> GetFormInfos();
        FormInfo GetFormInfo(int id);
        void CreateFormInfo(FormInfo formInfo);
        void UpdateFormInfo(FormInfo formInfo);
        void DeleteFormInfo(FormInfo formInfo);
        int CountFormInfo();

        void SaveFormInfo();
    }

    public class FormInfoService : IFormInfoService
    {
        private readonly IFormInfoRepository formInfoRepository;
        private readonly IUnitOfWork unitOfWork;
        public FormInfoService(IFormInfoRepository formInfoRepository, IUnitOfWork unitOfWork)
        {
            this.formInfoRepository = formInfoRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<FormInfo> GetFormInfos()
        {
            var formInfos = formInfoRepository.GetAll("FormType");
            return formInfos;
        }
        public FormInfo GetFormInfo(int id)
        {
            var formInfo = formInfoRepository.GetById(id);
            return formInfo;
        }
        public void CreateFormInfo(FormInfo formInfo)
        {
            formInfoRepository.Add(formInfo);
        }
        public void UpdateFormInfo(FormInfo formInfo)
        {
            formInfoRepository.Update(formInfo);
        }
        public void DeleteFormInfo(FormInfo formInfo)
        {
            formInfoRepository.Delete(formInfo);
        }
        public void SaveFormInfo()
        {
            unitOfWork.Commit();
        }
        public int CountFormInfo()
        {
            return formInfoRepository.GetAll().Count();
        }
    }
}
