using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class SeoSettingViewModel
    {
        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}