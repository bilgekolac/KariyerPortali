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
    public class PostController : BaseController
    {
        // GET: Post
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        public PostController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            
            ViewBag.Categories = new MultiSelectList(categoryService.GetCategories(), "CategoryId", "CategoryName", null);
            var postform = new PostFormViewModel();
            return View(postform);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostFormViewModel postFrom)
        {
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<PostFormViewModel, Post>(postFrom);
                List<Category> selectedCategories = new List<Category>();
                if (postFrom.CategoryId != null) 
                { 
                foreach (var item in postFrom.CategoryId)
                {
                    selectedCategories.Add(categoryService.GetCategory(item));
                }
                }
                post.Categories = selectedCategories;
                post.CreatedBy = User.Identity.Name;
                post.CreateDate = DateTime.Now;
                post.UpdatedBy = User.Identity.Name;
                post.UpdateDate = DateTime.Now;
                postService.CreatePost(post);
                postService.SavePost();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new MultiSelectList(categoryService.GetCategories(), "CategoryId", "CategoryName", postFrom.CategoryId);
            return View(postFrom);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var post = postService.GetPost(id.Value);
                if (post != null)
                {
                    var selectedcategories = post.Categories;
                    var selectedCategoryIds = new List<int>();
                    var postViewModel = Mapper.Map<Post, PostViewModel>(post);
                    foreach (var item in selectedcategories)
                    {
                        selectedCategoryIds.Add(item.CategoryId);
                    }
                    postViewModel.CategoryId = selectedCategoryIds;
                    ViewBag.Categories = new MultiSelectList(categoryService.GetCategories(), "CategoryId", "CategoryName", postViewModel.CategoryId);
                    return View(postViewModel);
                }
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PostFormViewModel postForm)
        {
            ViewBag.Categories = new MultiSelectList(categoryService.GetCategories(), "CategoryId", "CategoryName", postForm.CategoryId);
            if (ModelState.IsValid)
            {
                var post = Mapper.Map<PostFormViewModel, Post>(postForm);
                List<Category> selectedCategories = new List<Category>();
                if (postForm.CategoryId != null)
                {
                foreach (var item in postForm.CategoryId)
                {
                    selectedCategories.Add(categoryService.GetCategory(item));
                }
                }
                //post.CreateDate = post.CreateDate;
                //post.CreatedBy = post.CreatedBy;
                post.Categories = selectedCategories;
                post.UpdatedBy = User.Identity.Name;
                post.UpdateDate = DateTime.Now;
                postService.UpdatePost(post);
                postService.SavePost();
                return RedirectToAction("Index");
                
            }
            return View(postForm);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var post = postService.GetPost(id.Value);
                if (post != null)
                {
                    postService.DeletePost(post);
                    postService.SavePost();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
        public ActionResult Details(int? id)
        {
           
            if (id.HasValue)
            {
                var post = postService.GetPost(id.Value);
                if (post != null)
                {
                    postService.SavePost();
                    var postViewModel = Mapper.Map<Post, PostViewModel>(post);
                    ViewBag.Categories = new MultiSelectList(post.Categories, "CategoryId", "CategoryName", postViewModel.CategoryId);
                    
                    return View(postViewModel);
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
            var displayedPosts = postService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from p in displayedPosts select new[] { p.PostId.ToString(), p.PostId.ToString(), p.Title.ToString(), p.CreatedBy.ToString(), p.CreateDate.ToString(), string.Empty };
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