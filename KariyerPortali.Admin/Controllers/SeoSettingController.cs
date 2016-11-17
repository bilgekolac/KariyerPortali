using AutoMapper;
using KariyerPortali.Admin.Models;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class SeoSettingController : BaseController
    {
        private readonly ISeoSettingService seoSettingService;
        public SeoSettingController(ISeoSettingService seoSettingService)
        {
            this.seoSettingService = seoSettingService;
        }
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedSeoSettings = seoSettingService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedSeoSettings
                         select new[] { c.SeoSettingId.ToString(), c.Title, c.Description.ToString(), c.Keyword.ToString(), string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeoSettingFormViewModel seoSettingForm)
        {
            if (ModelState.IsValid)
            {
                var seoSetting = Mapper.Map<SeoSettingFormViewModel, SeoSetting>(seoSettingForm);

                seoSettingService.CreateSeoSetting(seoSetting);
                seoSettingService.SaveSeoSetting();
                return RedirectToAction("Index");
            }
            return View(seoSettingForm);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var seoSetting = seoSettingService.GetSeoSetting(id.Value);
                if (seoSetting != null)
                {
                    var seoSettingViewModel = Mapper.Map<SeoSetting, SeoSettingFormViewModel>(seoSetting);
                    return View(seoSettingViewModel);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeoSettingFormViewModel seoSettingForm)
        {
            if (ModelState.IsValid)
            {
                var seoSetting = Mapper.Map<SeoSettingFormViewModel, SeoSetting>(seoSettingForm);
                seoSettingService.UpdateSeoSetting(seoSetting);
                seoSettingService.SaveSeoSetting();
                return RedirectToAction("Index");
            }
            return View(seoSettingForm);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var seoSetting = seoSettingService.GetSeoSetting(id.Value);
                if (seoSetting != null)
                {
                    seoSettingService.DeleteSeoSetting(seoSetting);
                    seoSettingService.SaveSeoSetting();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
    }
}
