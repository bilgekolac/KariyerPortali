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
        public ActionResult Contact()
        {
            var settings = settingService.GetSettings();
            var settingViewModels = Mapper.Map<IEnumerable<Setting>, IEnumerable<SettingViewModel>>(settings);
            return View(settingViewModels);
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
                var setting1 = settingService.GetSettingByName("HeaderScript");
                setting1.Value = settingForm.HeaderScript;
                settingService.UpdateSetting(setting1);

                // google analytics setting güncellenir
                var setting2 = settingService.GetSettingByName("GoogleAnalytics"); 
                setting2.Value = settingForm.GoogleAnalytics;
                settingService.UpdateSetting(setting2);

                // footer script setting güncellenir
                var setting3 = settingService.GetSettingByName("FooterScript");
                setting3.Value = settingForm.FooterScript;
                settingService.UpdateSetting(setting3);

               

                // değişiklikler kaydedilir
                settingService.SaveSetting();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", new { error = "1" });
        }
        public ActionResult Contact(SettingFormViewModel settingForm2)
        {
         if (ModelState.IsValid)
         {
             var setting1 = settingService.GetSettingByName("Adres");
             setting1.Value = settingForm2.HeaderScript;
             settingService.UpdateSetting(setting1);

             // Adres setting güncellenir
             var setting2 = settingService.GetSettingByName("iletisim");
             setting2.Value = settingForm2.GoogleAnalytics;
             settingService.UpdateSetting(setting2);

             // iletisim setting güncellenir
             var setting3 = settingService.GetSettingByName("websayfasi");
             setting3.Value = settingForm2.FooterScript;
             settingService.UpdateSetting(setting3);

             // değişiklikler kaydedilir
             settingService.SaveSetting();
             return RedirectToAction("Contact");
         }
         return RedirectToAction("Contact", new { error = "1" });
        }
    }
}