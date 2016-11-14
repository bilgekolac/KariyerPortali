using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Reference
    {
        public int ReferenceId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EPosta { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }

       
        public int? SectorId { get; set; }
        public virtual Sector Sector { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }
        public string Message { get; set; }
        public string ReferenceFile { get; set; }

        public virtual ReferenceType ReferenceType { get; set; }

    }
}
