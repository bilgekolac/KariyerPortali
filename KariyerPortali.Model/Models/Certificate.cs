using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        public string CertificateName { get; set; }
        public string FileName { get; set; }
        public string Institute { get; set; }
        public DateTime CertificateDate { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
    }
}
