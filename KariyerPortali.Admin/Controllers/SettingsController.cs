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
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Theme()
        {
            return View();
        }
        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                var setting = settingService.GetSetting(id.Value);
                if (setting != null)
                {
                    var settingViewModel = Mapper.Map<Setting, SettingViewModel>(setting);
                    return View(settingViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SettingFormViewModel settingForm)
        {
            if (ModelState.IsValid)
            {
                var setting = Mapper.Map<SettingFormViewModel, Setting>(settingForm);
                settingService.UpdateSetting(setting);
                settingService.SaveSetting();
                return RedirectToAction("Index");
            }
            return View(settingForm);
        }
    }
}