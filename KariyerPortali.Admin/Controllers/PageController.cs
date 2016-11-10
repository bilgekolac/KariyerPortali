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
    public class PageController : BaseController
    {
        // GET: Pages
       private readonly IPageService PageService;
        private readonly ICountryService countryService;

        public PageController(IPageService PageService,ICountryService countryService)
        {
            this.PageService = PageService;
            this.countryService = countryService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.CountryId = new SelectList(countryService.GetCountries(), "CountryId", "CountryName");
          

            if (id.HasValue)
            {
                var Page = PageService.GetPage(id.Value);
                if (Page != null)
                {
                    var PageViewModel = Mapper.Map<Page, PageViewModel>(Page);
                    return View(PageViewModel);
                }

            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PageFormViewModel PageForm)
        {
            if (ModelState.IsValid)
            {
                var Page = Mapper.Map<PageFormViewModel, Page>(PageForm);
                PageService.UpdatePage(Page);
                PageService.SavePage();
                return RedirectToAction("Index");
            }
            return View(PageForm);
        }

      
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryService.GetCountries(), "CountryId", "CountryName");
          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PageFormViewModel formPage)
        {
            if (ModelState.IsValid)
            {
                var Page = Mapper.Map<PageFormViewModel, Page>(formPage);
                PageService.CreatePage(Page);             

                PageService.SavePage();
                return RedirectToAction("Index");
               
            }
            ViewBag.CountryId = new SelectList(countryService.GetCountries(), "CountryId", "CountryName");
            return View (formPage);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var Page = PageService.GetPage(id.Value);
                if (Page != null)
                {
                    PageService.DeletePage(Page);
                    PageService.SavePage();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
     

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
            var displayedCities = PageService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedCities
                         select new[] { c.PageId.ToString(), c.PageId.ToString(), c.PageName.ToString(),  string.Empty };
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