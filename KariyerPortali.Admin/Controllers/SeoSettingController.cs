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
    public class SettingController : BaseController
    {
        private readonly ISettingService SettingService;
        public SettingController(ISettingService SettingService)
        {
            this.SettingService = SettingService;
        }
        public ActionResult Theme()
        {

            return View();

        }
        public ActionResult Contact()
        {
            var Settings = SettingService.GetSettings();
            var SettingViewModels = Mapper.Map<IEnumerable<Setting>, IEnumerable<SeoSettingViewModel>>(Settings);
            return View(SettingViewModels);
        }
        public ActionResult Index()
        {
            var Settings = SettingService.GetSettings();
            var SettingViewModels = Mapper.Map<IEnumerable<Setting>, IEnumerable<SeoSettingViewModel>>(Settings);
            return View(SettingViewModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SeoSettingFormViewModel SettingForm)
        {
            if (ModelState.IsValid)
            {
                // header script setting güncellenir
                var Setting1 = SettingService.GetSettingByName("Title");
                Setting1.Value = SettingForm.Title;
                SettingService.UpdateSetting(Setting1);

                // google analytics setting güncellenir
                var Setting2 = SettingService.GetSettingByName("Description");
                Setting2.Value = SettingForm.Description;
                SettingService.UpdateSetting(Setting2);

                // footer script setting güncellenir
                var Setting3 = SettingService.GetSettingByName("Keyword");
                Setting3.Value = SettingForm.Keyword;
                SettingService.UpdateSetting(Setting3);



                // değişiklikler kaydedilir
                SettingService.SaveSetting();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index", new { error = "1" });
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SettingFormViewModel SettingForm)
        {
            if (ModelState.IsValid)
            {
                var Setting = Mapper.Map<SettingFormViewModel, Setting>(SettingForm);

                SettingService.CreateSetting(Setting);
                SettingService.SaveSetting();
                return RedirectToAction("Index");
            }
            return View(SettingForm);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var Setting = SettingService.GetSetting(id.Value);
                if (Setting != null)
                {
                    var SettingViewModel = Mapper.Map<Setting, SettingFormViewModel>(Setting);
                    return View(SettingViewModel);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SettingFormViewModel SettingForm)
        {
            if (ModelState.IsValid)
            {
                var Setting = Mapper.Map<SettingFormViewModel, Setting>(SettingForm);
                SettingService.UpdateSetting(Setting);
                SettingService.SaveSetting();
                return RedirectToAction("Index");
            }
            return View(SettingForm);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var Setting = SettingService.GetSetting(id.Value);
                if (Setting != null)
                {
                    SettingService.DeleteSetting(Setting);
                    SettingService.SaveSetting();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
    }
}
