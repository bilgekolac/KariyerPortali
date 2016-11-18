using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class SeoSettingFormViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }


    }
}