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
    public class JobController : Controller
    {
        private readonly IJobService jobService;
        private readonly IEmployerService employerService;
        private readonly ICityService cityService;
        private readonly IExperienceService experienceService;
        private readonly ISocialRightService socialService;

        public JobController(IJobService jobService, IEmployerService employerService, ICityService cityService, IExperienceService experienceService, ISocialRightService socialService)
        {
            this.jobService = jobService;
            this.employerService = employerService;
            this.cityService = cityService;
            this.experienceService = experienceService;
            this.socialService = socialService;
        }
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.EmployerId = new SelectList(employerService.GetEmployers(), "EmployerId", "EmployerName");
            ViewBag.CityId = new SelectList(cityService.GetCities(), "CityId", "CityName");
            ViewBag.ExperienceId = new SelectList(experienceService.GetExperiences(), "ExperienceId", "ExperienceName");
            var socialrights = new List<SocialRight>(socialService.GetSocialRights());
            var socialrightnames = new string[socialrights.Count()];
            for (int i = 0; i < socialrights.Count(); i++) {
                socialrightnames[i] = socialrights[i].SocialRightName;
                    }
            ViewBag.SocialRightNames = socialrightnames;
            return View();
        }
        public ActionResult Liste()
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
            var displayedJobs = jobService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedJobs
                         select new[] {c.JobId.ToString(), c.Title.ToString(), c.Description.ToString(), (c.Employer != null ? c.Employer.EmployerName.ToString() : string.Empty), (c.Employer != null ? c.City.CityName.ToString() : string.Empty), c.JobType.ToString(), c.Createdate.ToShortDateString(),string.Empty};
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