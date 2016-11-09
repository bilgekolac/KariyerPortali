using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class JobApplicationViewModel
    {
        public int ApplicationId { get; set; }

        public string CoverLetter { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }


        public int EmployerId { get; set; }
        public Employer Employer { get; set; }


        public int JobId { get; set; }
        public Job Job { get; set; }

        public int SectorId { get; set; }
        public Sector Sector { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

    }
}