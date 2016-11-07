﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class FileViewModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Description { get; set; }

    }
}