using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model.Models
{
   public class Redirect
    {
        public int RedirectId { get; set; }
        public string RedirectName { get; set; }
        public string OldUrl { get; set; }
        public string NewUrl { get; set; }

    }
}
