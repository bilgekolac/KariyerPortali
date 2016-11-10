using AutoMapper;
using KariyerPortali.Admin.Models;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class LanguageController : BaseController
    {
        private readonly ILanguageService languageService;

        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }
        
        // GET: Language
        public ActionResult Index()
        {
 
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LanguageFormViewModel languageForm)
        {
            if (ModelState.IsValid)
            {
                var language = Mapper.Map<LanguageFormViewModel, Language>(languageForm);
                languageService.CreateLanguage(language);
                languageService.SaveLanguage();
                return RedirectToAction("Index");
            }
            return View(languageForm);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var language = languageService.GetLanguage(id.Value);
                if (language != null)
                {
                    var languageViewModel = Mapper.Map<Language, LanguageViewModel>(language);
                    return View(languageViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LanguageFormViewModel languageForm)
        {
            if (ModelState.IsValid)
            {
                var language = Mapper.Map<LanguageFormViewModel, Language>(languageForm);
                languageService.UpdateLanguage(language);
                languageService.SaveLanguage();
                return RedirectToAction("Index");
            }
            return View(languageForm);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var language = languageService.GetLanguage(id.Value);
                if (language != null)
                {
                    languageService.DeleteLanguage(language);
                    languageService.SaveLanguage();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
  
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedLanguages = languageService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from l in displayedLanguages
                         select new[] { l.LanguageId.ToString(), l.LanguageId.ToString(), l.LanguageName.ToString(), string.Empty };
            
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
               JsonRequestBehavior.AllowGet);

        }
    }
}