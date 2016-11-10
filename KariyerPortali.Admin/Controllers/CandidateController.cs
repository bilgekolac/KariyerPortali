using AutoMapper;
using KariyerPortali.Admin.Models;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateService candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }
        // GET: Candidate
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
            var displayedCandidates = candidateService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedCandidates
                         select new[] { c.CandidateId.ToString(), c.UserName, c.FirstName + " " + c.LastName, c.Phone.ToString(), c.Email.ToString(), c.State.ToString(), c.CreateDate.ToShortDateString(), string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var candidate = candidateService.GetCandidate(id.Value);
                if (candidate != null)
                {
                    candidateService.DeleteCandidate(candidate);
                    candidateService.SaveCandidate();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var candidate = candidateService.GetCandidate(id.Value);
                if (candidate != null)
                {
                    var candidateViewModel = Mapper.Map<Candidate, CandidateViewModel>(candidate);
                    return View(candidateViewModel);
                }
            }
            return HttpNotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CandidateFormViewModel candidateForm, System.Web.HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var candidate = Mapper.Map<CandidateFormViewModel, Candidate>(candidateForm);
                candidate.UpdatedBy = User.Identity.Name;
                candidate.CreateDate = DateTime.Now;
                candidate.UpdatedDate = candidate.CreateDate;
                if (upload != null)
                {
                    string dosyaYolu = Path.GetFileName(upload.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Uploads/Candidate"), dosyaYolu);
                    upload.SaveAs(yuklemeYeri);
                    candidate.Photo = upload.FileName;
                }
                candidateService.UpdateCandidate(candidate);
                candidateService.SaveCandidate();
                return RedirectToAction("Index");
            }
            return View(candidateForm);
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var candidate = candidateService.GetCandidate(id.Value);
                if (candidate != null)
                {
                    //candidateService.DeleteCandidate(candidate);
                    candidateService.SaveCandidate();
                    var candidateViewModel = Mapper.Map<Candidate, CandidateViewModel>(candidate);
                    return View(candidateViewModel);
                }
            }
            return HttpNotFound();
        }
    }
}
