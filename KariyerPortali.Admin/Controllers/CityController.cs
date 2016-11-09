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
    public class CityController : Controller
    {
        // GET: City
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        public CityController(ICityService cityService,ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }

        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Edit(int? id)
        //{

        //    var city = cityService.GetCity(id.Value);
        //    return View(city);
            
        //}

        //[HttpPost]
        //public ActionResult Edit(City city)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        cityService.UpdateCity(city);
        //        cityService.SaveCity();
        //        return RedirectToAction("Index");
                
        //    }
        //    return View(city);
        //}

      
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryService.GetCountries(), "CountryId", "CountryName");
          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityFormViewModel formCity)
        {
            if (ModelState.IsValid)
            {
                var city = Mapper.Map<CityFormViewModel, City>(formCity);
                cityService.CreateCity(city);             

                cityService.SaveCity();
                return RedirectToAction("Index");
               
            }
            ViewBag.CountryId = new SelectList(countryService.GetCountries(), "CountryId", "CountryName");
            return View (formCity);
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
            var displayedCities = cityService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedCities
                         select new[] { c.CityId.ToString(), c.CityId.ToString(), c.CityName.ToString(),  string.Empty };
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