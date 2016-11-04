﻿using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KariyerPortali.Service
{
    public interface ILanguageService
    {
        IEnumerable<Language> Search(string search);
        IEnumerable<Language> GetLanguages();
        Language GetLanguage(int id);
        void CreateLanguage(Language language);
        void UpdateLanguage(Language language);
        void DeleteLanguage(Language language);
        void SaveLanguage();
    }
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository languageRepository;
        private readonly IUnitOfWork unitOfWork;
        public LanguageService(ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
        {
            this.languageRepository = languageRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ILanguageService Members
        public IEnumerable<Language> Search(string search)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = GetLanguages();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(l => l.LanguageId.ToString().Contains(sSearch) || l.LanguageName.Contains(sSearch));
                }
            }
            return query;

        }
        public IEnumerable<Language> GetLanguages()
        {
            var languages = languageRepository.GetAll();
            return languages;
        }
        public Language GetLanguage(int id)
        {
            var language = languageRepository.GetById(id);
            return language;
        }
        public void CreateLanguage(Language language)
        {
            languageRepository.Add(language);
        }
        public void UpdateLanguage(Language language)
        {
            languageRepository.Update(language);
        }
        public void DeleteLanguage(Language language)
        {
            languageRepository.Delete(language);
        }
        public void SaveLanguage()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
