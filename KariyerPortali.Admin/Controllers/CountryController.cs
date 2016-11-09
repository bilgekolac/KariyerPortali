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
    public class CountryController : Controller
    {
      

        private readonly ICountryService countryService;

         public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        // GET: Country
        public ActionResult Index()
        {
            
            return View();
           
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Edit()
        {
           
            return View();
        }
        public ActionResult Delete()
         {
             return View();
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryFormViewModel countryForm)
        {
            if (ModelState.IsValid)
            {
                var country = Mapper.Map<CountryFormViewModel, Country>(countryForm);

                countryService.CreateCountry(country);
                countryService.SaveCountry();
                return RedirectToAction("Index");
            }
            return View(countryForm);
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedCountries = countryService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedCountries
                         select new[] {  string.Empty, c.CountryId.ToString(), c.CountryName, string.Empty };
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