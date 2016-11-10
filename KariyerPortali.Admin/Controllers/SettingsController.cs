using AutoMapper;
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
    public class SettingsController : BaseController
    {
         private readonly ISettingService settingService;

         public SettingsController(ISettingService settingService)
        {
            this.settingService = settingService;
        }
       
        public ActionResult Theme()
        {
            return View();
        }
        public ActionResult Index()
        {
            var settings = settingService.GetSettings();
            var settingViewModels = Mapper.Map<IEnumerable<Setting>, IEnumerable<SettingViewModel>>(settings);
            return View(settingViewModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SettingFormViewModel settingForm)
        {
            if (ModelState.IsValid)
            {
                // header script setting güncellenir
                var setting1 = settingService.GetSetting(1); // servise ve repository'e GetSettingByName metodu eklenir
                setting1.Value = settingForm.HeaderScript;
                settingService.UpdateSetting(setting1);

                // google analytics setting güncellenir

                // footer script setting güncellenir

                // değişiklikler kaydedilir
                settingService.SaveSetting();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", new { error = "1" });
        }
    }
}