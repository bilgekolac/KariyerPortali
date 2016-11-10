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
    public class ResumeController : BaseController 
    {
        private readonly IResumeService resumeService;
       

        public ResumeController(IResumeService resumeService)
        {
            this.resumeService = resumeService;
           
        }
        // GET: Resume
        public ActionResult Index()
        {
            return View();
        }

       //Create ve Edit Action Olmayacak 
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var resume = resumeService.GetResume(id.Value);
                if (resume != null)
                {                  
                    resumeService.SaveResume();
                    var resumeViewModel = Mapper.Map<Resume, ResumeViewModel>(resume);
                    return View(resumeViewModel);
                }
            }
            return HttpNotFound();
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedResumes = resumeService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedResumes
                         select new[] { c.ResumeId.ToString(), c.ResumeId.ToString(), c.FirstName,c.LastName,c.Gender.ToString(),
                         c.ComputerSkill,c.Notes.ToString(),c.WorkStatus.ToString(),string.Empty};
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