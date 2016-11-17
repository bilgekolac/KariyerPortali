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
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.ParentCategoryId = new SelectList(categoryService.GetCategories(), "ParentCategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CategoryFormViewModel categoryFrom)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<CategoryFormViewModel, Category>(categoryFrom);                
                categoryService.CreateCategory(category);
                categoryService.SaveCategory();
                return RedirectToAction("Index");
            }
            return View(categoryFrom);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var category = categoryService.GetCategory(id.Value);
                if (category != null)
                {
                    var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);
                    ViewBag.ParentCategoryId = new SelectList(categoryService.GetCategories(), "ParentCategoryId", "CategoryName", category.ParentCategoryId);
                    return View(categoryViewModel);
                }
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CategoryFormViewModel categoryForm)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<CategoryFormViewModel, Category>(categoryForm);               
                categoryService.UpdateCategory(category);
                categoryService.SaveCategory();
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryId = new SelectList(categoryService.GetCategories(), "ParentCategoryId", "CategoryName", categoryForm.ParentCategoryId);
            return View(categoryForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var category = categoryService.GetCategory(id.Value);
                if (category != null)
                {
                    categoryService.DeleteCategory(category);
                    categoryService.SaveCategory();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"];
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedCategories = categoryService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from c in displayedCategories select new[] { c.CategoryId.ToString(), c.CategoryId.ToString(), c.CategoryName, c.Slug, c.PostCount.ToString(), string.Empty };
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