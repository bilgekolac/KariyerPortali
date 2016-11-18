using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Link
    {
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public string Url { get; set; }
        public bool Visible { get; set; }
    }
}
