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
    public class ApplicationsController : Controller
    {
        // GET: Applications
        private readonly IJobApplicationService jobApplicationService;

        public ApplicationsController(IJobApplicationService jobApplicationService)
        {
            this.jobApplicationService = jobApplicationService;
        }

        public ActionResult Index()
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
            var displayedJobsAplications = jobApplicationService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);


            var result = from j in displayedJobsAplications
                         select new[] {j.JobApplicationId.ToString(), (j.Candidate != null ? j.Candidate.FirstName.ToString():string.Empty),
                             (j.Candidate != null ? j.Candidate.LastName.ToString():string.Empty),
                             (j.Employer != null ? j.Employer.EmployerName.ToString():string.Empty ),
                             (j.Job !=null ? j.Job.Title.ToString():string.Empty), j.ApplicationDate.ToShortDateString(),
                             j.UpdateDate.ToShortTimeString(), string.Empty};
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result
            },
                JsonRequestBehavior.AllowGet);

        }

        public ActionResult Details(int id)
        {
            var JobApplication = jobApplicationService.GetJobApplication(id);
                return View(Mapper.Map<JobApplication, JobApplicationViewModel>(JobApplication));

        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var jobapplication = jobApplicationService.GetJobApplication(id.Value);
                if (jobapplication != null)
                {
                    jobApplicationService.DeleteJobApplication(jobapplication);
                    jobApplicationService.SaveJobApplication();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
    }
}


            