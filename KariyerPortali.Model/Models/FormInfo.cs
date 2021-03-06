﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class FormInfo
    {
        public int FormInfoId { get; set; }

        public string FormInfoDescription { get; set; }

        public bool Required { get; set; }

        public string Value { get; set; }

        public virtual FormType FormType { get; set; }

        public virtual Form Form { get; set; }
    }
}
