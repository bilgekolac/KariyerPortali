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
    public class CountryController : BaseController
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
                         select new[] { c.CountryId.ToString(), c.CountryId.ToString(), c.CountryName, string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
                JsonRequestBehavior.AllowGet);
          
        }
      
       
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            { 
                var country = countryService.GetCountry(id.Value);
                if (country != null) {
                    var countryViewModel = Mapper.Map<Country, CountryViewModel>(country);
                    return View(countryViewModel);
                }
                
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryFormViewModel countryForm)
        {
            if (ModelState.IsValid)
            {
                var country = Mapper.Map<CountryFormViewModel, Country>(countryForm);
                countryService.UpdateCountry(country);
                countryService.SaveCountry();
                return RedirectToAction("Index");
            }
            return View(countryForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var country = countryService.GetCountry(id.Value);
                if (country != null)
                {
                    countryService.DeleteCountry(country);
                    countryService.SaveCountry();
                    return RedirectToAction("Index");
                }

            }
            return HttpNotFound();
        }
      
    }
}