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
            ViewBag.SocialRights = new MultiSelectList(socialService.GetSocialRights(), "SocialRightId", "SocialRightName", null);

            //var socialrightNames = new string[socialrights.Count()];
            //for (int i = 0; i < socialrights.Count(); i++) {
            //    socialrightNames[i] = socialrights[i].SocialRightName;
            //        }
            //ViewBag.SocialRightNames = socialrightNames;
            //var selectSocialRight = new List<SocialRight>();
            //ViewBag.selectSocialRight = selectSocialRight;
            var jobform = new JobFormViewModel();
            return View(jobform);
        }

        [HttpPost]
        public ActionResult Create(JobFormViewModel jobForm)
        {
            if (ModelState.IsValid)
            {
                var job = Mapper.Map<JobFormViewModel, Job>(jobForm);
                jobService.CreateJob(job);

                jobService.SaveJob();
                return RedirectToAction("Index");

            }
            ViewBag.EmployerId = new SelectList(employerService.GetEmployers(), "EmployerId", "EmployerName");
            ViewBag.CityId = new SelectList(cityService.GetCities(), "CityId", "CityName");
            ViewBag.ExperienceId = new SelectList(experienceService.GetExperiences(), "ExperienceId", "ExperienceName");
            ViewBag.SocialRights = new MultiSelectList(socialService.GetSocialRights(), "SocialRightId", "SocialRightName", jobForm.SocialRightId);
            return View(jobForm);
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