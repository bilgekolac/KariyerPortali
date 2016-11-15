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
    public interface IFormService
    {
        IEnumerable<Form> GetForms();
        Form GetForm(int id);
        void CreateForm(Form form);
        void UpdateForm(Form form);
        void DeleteForm(Form form);
        int CountForm();

        void SaveForm();
    }

    public class FormService:IFormService
    {
        private readonly IFormRepository formRepository;
        private readonly IUnitOfWork unitOfWork;
        public FormService(IFormRepository formRepository, IUnitOfWork unitOfWork)
        {
            this.formRepository = formRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Form> GetForms()
        {
            var forms = formRepository.GetAll("FormInfo");
            return forms;
        }
        public Form GetForm(int id)
        {
            var form = formRepository.GetById(id);
            return form;
        }
        public void CreateForm(Form form)
        {
            formRepository.Add(form);
        }
        public void UpdateForm(Form form)
        {
            formRepository.Update(form);
        }
        public void DeleteForm(Form form)
        {
            formRepository.Delete(form);
        }
        public void SaveForm()
        {
            unitOfWork.Commit();
        }
        public int CountForm()
        {
            return formRepository.GetAll().Count();
        }
    }
}
