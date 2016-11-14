using KariyerPortali.Admin.Models;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IJobApplicationService jobApplicationService;
         private readonly ICandidateService candidateService;
         private readonly IJobService jobService;
         private readonly IResumeService resumeService;
         public HomeController(IJobApplicationService jobApplicationService, ICandidateService candidateService, IJobService jobService, IResumeService resumeService)
        {
            this.jobApplicationService = jobApplicationService;
            this.candidateService = candidateService;
            this.jobService = jobService;
            this.resumeService = resumeService;
        }
       

       
        public ActionResult Index()
        {
            ViewBag.JobApplicationCount = jobApplicationService.CountJobApplication();

            ViewBag.JobApplicationMonth1 = jobApplicationService.GetJobApplicationCountByMonth(1);
            ViewBag.JobApplicationMonth2 = jobApplicationService.GetJobApplicationCountByMonth(2);
            ViewBag.JobApplicationMonth3 = jobApplicationService.GetJobApplicationCountByMonth(3);
            ViewBag.JobApplicationMonth4 = jobApplicationService.GetJobApplicationCountByMonth(4);
            ViewBag.JobApplicationMonth5 = jobApplicationService.GetJobApplicationCountByMonth(5);
            ViewBag.JobApplicationMonth6 = jobApplicationService.GetJobApplicationCountByMonth(6);
            ViewBag.JobApplicationMonth7 = jobApplicationService.GetJobApplicationCountByMonth(7);
            ViewBag.JobApplicationMonth8 = jobApplicationService.GetJobApplicationCountByMonth(8);
            ViewBag.JobApplicationMonth9 = jobApplicationService.GetJobApplicationCountByMonth(9);
            ViewBag.JobApplicationMonth10 = jobApplicationService.GetJobApplicationCountByMonth(10);
            ViewBag.JobApplicationMonth11 = jobApplicationService.GetJobApplicationCountByMonth(11);
            ViewBag.JobApplicationMonth12 = jobApplicationService.GetJobApplicationCountByMonth(12);
            ViewBag.CandidateCount = candidateService.CountCandidate();
            ViewBag.ResumeCount = resumeService.CountResume();
            ViewBag.JobCount = jobService.CountJob();
            return View();
        }

        public ActionResult About()
        {
            System.Net.WebClient myWebClient;
            myWebClient = new System.Net.WebClient();

            Byte[] buffer;
            buffer = myWebClient.DownloadData("http://connect.kliksoft.net/rh/?launcher=false&guestname=Murat%20Demirci");
            string content;

            content = System.Text.Encoding.UTF8.GetString(buffer);

            return View(model:content);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}