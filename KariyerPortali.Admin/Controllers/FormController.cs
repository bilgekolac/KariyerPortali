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
        public FormController(IFormService formService)
        {
            this.formService = formService;
        }
        // GET: Form
        public ActionResult CreateForm()
        {
            var jobform = new FormFormViewModel();
            return View(jobform);
        }

        //[HttpPost]
        //public ActionResult CreateForm(FormFormViewModel form)
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

        public ActionResult FormDetails(/*int id*/)
        {
            return View();
        }

        public ActionResult CreateFormInfo(FormFormViewModel form)
        {
            return View();
        }
    }
}