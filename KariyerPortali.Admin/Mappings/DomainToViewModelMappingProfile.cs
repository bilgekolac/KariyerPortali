using AutoMapper;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
         public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Mapper.CreateMap<Resume, ResumeViewModel>();
            Mapper.CreateMap<Country, CountryViewModel>();
            Mapper.CreateMap<City, CityViewModel>();
            Mapper.CreateMap<Candidate, CandidateViewModel>();
            Mapper.CreateMap<Job, JobViewModel>();
            Mapper.CreateMap<Language, LanguageViewModel>();
            Mapper.CreateMap<Department, DepartmentViewModel>();
            Mapper.CreateMap<JobApplication, JobApplicationViewModel>();
            Mapper.CreateMap<University, UniversityViewModel>();
            Mapper.CreateMap<Employer, EmployerViewModel>();
            Mapper.CreateMap<File, FileViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Exam, ExamViewModel>();
            Mapper.CreateMap<Expertise, ExpertiseViewModel>();
            Mapper.CreateMap<Skill, SkillViewModel>();

#pragma warning restore CS0618 // Type or member is obsolete
        }
    
    }
}