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
    public class ExamController : Controller
    {


        private readonly IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }
        // GET: Exam
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
        public ActionResult Create(ExamFormViewModel examForm)
        {
            if (ModelState.IsValid)
            {
                var exam = Mapper.Map<ExamFormViewModel, Exam>(examForm);

                examService.CreateExam(exam);
                examService.SaveExam();
                return RedirectToAction("Index");
            }
            return View(examForm);
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedExams = examService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from e in displayedExams
                         select new[] { e.ExamId.ToString(), e.ExamId.ToString(), e.ExamName, string.Empty };
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
                var exam = examService.GetExam(id.Value);
                if (exam != null)
                {
                    var examViewModel = Mapper.Map<Exam, ExamViewModel>(exam);
                    return View(examViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamFormViewModel examForm)
        {
            if (ModelState.IsValid)
            {
                var exam = Mapper.Map<ExamFormViewModel, Exam>(examForm);
                examService.UpdateExam(exam);
                examService.SaveExam();
                return RedirectToAction("Index");
            }
            return View(examForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var exam = examService.GetExam(id.Value);
                if (exam != null)
                {
                    examService.DeleteExam(exam);
                    examService.SaveExam();
                    return RedirectToAction("Index");
                }

            }
            return HttpNotFound();
        }

    }
}