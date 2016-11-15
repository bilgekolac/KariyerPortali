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
        public ActionResult Index()
        {
            return View();
        }
    }
}