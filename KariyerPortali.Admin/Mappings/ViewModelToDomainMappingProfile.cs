using AutoMapper;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.Mappings
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EmployerFormViewModel, Employer>();
            Mapper.CreateMap<DepartmentFormViewModel, Department>();
            Mapper.CreateMap<LanguageFormViewModel, Language>();
            Mapper.CreateMap<CountryFormViewModel, Country>();           
            Mapper.CreateMap<CityFormViewModel, City>();
            Mapper.CreateMap<UniversityFormViewModel, University>();
            
        }
    }
}