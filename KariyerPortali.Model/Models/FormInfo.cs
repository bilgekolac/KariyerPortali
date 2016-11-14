using KariyerPortali.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model.Models
{
    public class FormInfo
    {
        public int FormInfoId { get; set; }

        public string FormInfoDescription { get; set; }

        public string Value { get; set; }

        public int? FormTypeId { get; set; }

        public virtual FormType FormType { get; set; }
    }
}
