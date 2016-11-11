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
    public class SkillController :BaseController
    {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }
        // GET: Skill
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
        public ActionResult Create(SkillFormViewModel skillForm)
        {
            if (ModelState.IsValid)
            {
                var skill = Mapper.Map<SkillFormViewModel, Skill>(skillForm);

                skillService.CreateSkill(skill);
                skillService.SaveSkill();
                return RedirectToAction("Index");
            }
            return View(skillForm);
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedSkills = skillService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedSkills
                         select new[] { c.SkillId.ToString(), c.SkillId.ToString(), c.SkillName, string.Empty };
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
                var skill = skillService.GetSkill(id.Value);
                if (skill != null)
                {
                    var skillViewModel = Mapper.Map<Skill, SkillViewModel>(skill);
                    return View(skillViewModel);
                }

            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SkillFormViewModel skillForm)
        {
            if (ModelState.IsValid)
            {
                var skill = Mapper.Map<SkillFormViewModel, Skill>(skillForm);
                skillService.UpdateSkill(skill);
                skillService.SaveSkill();
                return RedirectToAction("Index");
            }
            return View(skillForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var skill = skillService.GetSkill(id.Value);
                if (skill != null)
                {
                    skillService.DeleteSkill(skill);
                    skillService.SaveSkill();
                    return RedirectToAction("Index");
                }

            }
            return HttpNotFound();
        }



    }
}