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
        public ActionResult IndexSeo()
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(SettingFormViewModel settingForm2)
        {
         if (ModelState.IsValid)
         {
             var setting4 = settingService.GetSettingByName("Adres");
             setting4.Value = settingForm2.HeaderScript;
             settingService.UpdateSetting(setting4);

             // Adres setting güncellenir
             var setting5 = settingService.GetSettingByName("Iletisim");
             setting5.Value = settingForm2.GoogleAnalytics;
             settingService.UpdateSetting(setting5);

             // iletisim setting güncellenir
             var setting6 = settingService.GetSettingByName("websayfa");
             setting6.Value = settingForm2.FooterScript;
             settingService.UpdateSetting(setting6);

             // değişiklikler kaydedilir
             settingService.SaveSetting();
             return RedirectToAction("Contact");
         }
         return RedirectToAction("Contact", new { error = "1" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexSeo(SettingFormViewModel settingForm)
             {
        
                if (ModelState.IsValid)
                {
                    // header script setting güncellenir
                    var setting7 = settingService.GetSettingByName("Title");
                    setting7.Value = settingForm.Title;
                    settingService.UpdateSetting(setting7);

                    // google analytics setting güncellenir
                    var setting8 = settingService.GetSettingByName("Description");
                    setting8.Value = settingForm.Description;
                    settingService.UpdateSetting(setting8);

                    // footer script setting güncellenir
                    var setting9 = settingService.GetSettingByName("Keyword");
                    setting9.Value = settingForm.Keyword;
                    settingService.UpdateSetting(setting9);



                    // değişiklikler kaydedilir
                    settingService.SaveSetting();
                    return RedirectToAction("IndexSeo");

                }
                return RedirectToAction("IndexSeo", new { error = "1" });
            }
        }

    }
