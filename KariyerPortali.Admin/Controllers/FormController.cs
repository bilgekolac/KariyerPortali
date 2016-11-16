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
    public class FormController : BaseController
    {
        private readonly IFormService formService;
        private readonly IFormInfoService formInfoService;
        public FormController(IFormService formService, IFormInfoService formInfoService)
        {
            this.formService = formService;
            this.formInfoService = formInfoService;
        }
        // GET: Form
        public ActionResult Create()
        {
            var form = new FormFormViewModel();
            return View(form);
        }

        //[HttpPost]
        //public ActionResult Create(FormFormViewModel form)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var frm = Mapper.Map<FormFormViewModel, Form>(form);
        //        List<SocialRight> selectedSocialRights = new List<SocialRight>();
        //        foreach (var item in form.SocialRightId)
        //        {
        //            selectedSocialRights.Add(socialService.GetSocialRight(item));
        //        }
        //        job.SocialRights = selectedSocialRights;
        //        job.Createdate = DateTime.Now;
        //        job.CreatedBy = User.Identity.Name;
        //        job.UpdateDate = DateTime.Now;
        //        job.UpdatedBy = User.Identity.Name;
        //        jobService.CreateJob(job);

        //        jobService.SaveJob();
        //        return RedirectToAction("Index");

        //    }
        //    ViewBag.EmployerId = new SelectList(employerService.GetEmployers(), "EmployerId", "EmployerName");
        //    ViewBag.CityId = new SelectList(cityService.GetCities(), "CityId", "CityName");
        //    ViewBag.ExperienceId = new SelectList(experienceService.GetExperiences(), "ExperienceId", "ExperienceName");
        //    ViewBag.SocialRights = new MultiSelectList(socialService.GetSocialRights(), "SocialRightId", "SocialRightName", jobForm.SocialRightId);
        //    return View(jobForm);

        //}

        public ActionResult Details(int? id)
        {
            return View();
        }
    }
}