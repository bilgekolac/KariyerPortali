using System.Collections.Generic;
using System.ComponentModel;

namespace KariyerPortali.Model
{
    public class Country
    {

        
        public int CountryId { get; set; }
          [DisplayName("Ülke")]
        public string CountryName{ get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
    }
}