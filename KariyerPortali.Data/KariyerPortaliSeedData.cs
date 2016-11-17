using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data
{
    public class KariyerPortaliSeedData : DropCreateDatabaseIfModelChanges<KariyerPortaliEntities>
    {
        
        protected override void Seed(KariyerPortaliEntities context)
        {
            GetSectors().ForEach(c => context.Sectors.Add(c));
            GetSkills().ForEach(c => context.Skills.Add(c));
            GetSkillInfos().ForEach(c => context.SkillInfos.Add(c));
            GetCandidates().ForEach(c => context.Candidates.Add(c));
            GetDepartments().ForEach(c => context.Departments.Add(c));
            GetUniversities().ForEach(c => context.Universities.Add(c));
            GetHighSchoolTypes().ForEach(c => context.HighSchollTypes.Add(c));
            GetHighSchoolDeparments().ForEach(c => context.HighSchollDepartments.Add(c));
            GetCountries().ForEach(c => context.Countries.Add(c));
            GetCities().ForEach(c => context.Cities.Add(c));
            GetLanguages().ForEach(c => context.Languages.Add(c));
            GetResumes().ForEach(c => context.Resumes.Add(c));


            context.Commit();
        }
        private  List<Candidate> GetCandidates()
        {
            return new List<Candidate>
            {
                new Candidate {

                    CandidateId=1,
                    UserName="muhammed",
                    FirstName="Muhammed",
                    LastName="SEZGİN",
                    Email="muhammed.sezgin88@gmail.com",
                    Phone="(0539)-6451032",
                    BirthDate= Convert.ToDateTime("05.11.1988"),
                    Photo=null,
                    CreateDate =DateTime.Now,
                    State =true,
                    UpdatedBy= "muhammed",
                    UpdatedDate=DateTime.Now,

                },

            };
        }
        private  List<HighSchoolType> GetHighSchoolTypes()
        {
            return new List<HighSchoolType>
            {
                new HighSchoolType{

                    HighSchoolTypeId =1,
                    TypeName="Anadolu Lisesi",

                },

            };
        }
        private  List<HighSchoolDepartment> GetHighSchoolDeparments()
        {
            return new List<HighSchoolDepartment>
            {
                new HighSchoolDepartment {
                    HighSchoolDepartmentId=1,
                    DepartmentName="Sayısal",
                },

            };
        }
        private  List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country {
                    CountryId=1,
                    CountryName="Türkiye",

                },

            };
        }
        private  List<City> GetCities()
        {
            return new List<City>
            {
                new City {

                    CityId =1,
                    CityName="Erzincan",
                                        
                             
                },

            };
        }
        private List<Language> GetLanguages()
        {
            return new List<Language>
            {
                new Language {
                    LanguageId=1,
                    LanguageName="İngilizce"},
            
                new Language{LanguageId=2,LanguageName="Fransızca"},
            
            };

        
        
        }

        private  List<Sector> GetSectors()
        {
            return new List<Sector>
            {
                new Sector {
                  SectorId=1,
                  SectorName="Bilişim"},
              
            };


        }

        private  List<Skill> GetSkills()
        {
            return new List<Skill>
            {
                new Skill {
                SkillId=1,
                SkillName="C#",
                },
              
            };


        }

        private List<SkillInfo> GetSkillInfos()
        {
            return new List<SkillInfo>
            {
                new SkillInfo {
               SkillId=1,
               SkillInfoId=1,             
               Point=5,
                },
              
            };


        }


        private List<University> GetUniversities()
        {
            return new List<University>
            {

                new University {
                    UniversityId=1,
                    UniversityName="Yıldız Teknik Üniversitesi"},

                new University {
                    UniversityId=2,
                    UniversityName="Ankara Üniversitesi"},
                



            };
        }

        private List<Department> GetDepartments()
        {
            return new List<Department>
            {

                  new Department {

                    DepartmentId=1,
                    DepartmentName="Elektronik-Haberleşme Mühendisliği"

                },
                  new Department {
                    
                    DepartmentId=2,
                    DepartmentName="Fizik Mühendisliği"
                    
                },
              
            };
        }

       
        private List<Resume> GetResumes()
        {
            var resumes = new List<Resume>();  
                
            var resume = new Resume {
                ViewCount=0,
                ResumeId=1,
                ResumeName="muhammedCV",
                Notes= "C# , .NET , ADO.NET ",
                FirstName="Muhammed",
                LastName="SEZGİN",
                CitizenshipId="20902981214",
                CreatedBy="muhammed",
                UpdatedBy="muhammed",
                CoverLetter="Merhaba, Bilişim Eğitim Merkezi",
                Email="muhammed.sezgin88@gmail.com",
                CellPhone="(0539)-645-4545",
                CellPhone2="(0505)-444-1444",
                HomePhone="(0212)-444-1111",
                Website="www.muhammedsezgin.wordpress.com",
                Address="Bahçeşehir/İSTANBUL",
                HighSchoolName="Bahçeşehir Atatürk Anadolu Lisesi",
                ComputerSkill="C#, Matlab , PhotoShop, AutoCAD ,SQL Server",
                ScholarshipAndProject="Kariyer Portalı",
                Hobby="Müzik,Spor",
                MemberOwnedCommunity="TEV",
                DrivingLicenseExists= true,
                HighSchoolStart= Convert.ToDateTime("09.08.2002"),
                HighSchoolEnd= Convert.ToDateTime("07.07.2006"),
                UpdateDate=DateTime.Now,
                BirthDate=Convert.ToDateTime("05.11.1988"),
                CreateDate=Convert.ToDateTime("11.11.2016"),
                MilitaryPostponeDate=Convert.ToDateTime("18.04.2018"),
                LanguageId=1,
                CandidateId=1,
                Gender = Gender.Male,
                BirthCityId=1,
                MaritalStatus =MaritalStatus.Single,
                WorkStatus =WorkStatus.Active,
                CountryId=1,
                MilitaryService=MilitaryService.Postpone,
                DrivingLicense1Class = DrivingLicenseClass.B,
                DrivingLicense2Class= DrivingLicenseClass.A1,
                DrivingLicense1Date = Convert.ToDateTime("05.08.2008"),
                DrivingLicense2Date= Convert.ToDateTime("04.07.2009"),
                HighSchoolTypeId=1,
                HighSchoolDepartmentId=1,
                HighSchoolCertificate=HighSchoolCertificate.N100,
                HighSchoolDegree= 75,
                CertificateDegree= 3,
                BloodType = BloodType.ARhP,
                CigaretteStatus = CigaretteStatus.Yes,
                SalaryWaited = SalaryWaited.B3000and4000,
                
            };

            resume.LanguageInfos = new List<LanguageInfo>();
            resume.LanguageInfos.Add(new LanguageInfo() { LanguageInfoId = 1, LanguageId = 1, ReadingLanguageLevel = LanguageLevel.Advance, WritingLanguageLevel = LanguageLevel.Advance, SpeakingLanguageLevel = LanguageLevel.Good });
            resume.LanguageInfos.Add(new LanguageInfo() { LanguageInfoId = 1, LanguageId = 2, ReadingLanguageLevel = LanguageLevel.Advance, WritingLanguageLevel = LanguageLevel.Advance, SpeakingLanguageLevel = LanguageLevel.Good });
                   
         
            resume.EducationInfos = new List<EducationInfo>();
            resume.EducationInfos.Add(new EducationInfo() { EducationInfoId = 1, EducationStatus = EducationStatus.Master, UniversityId = 1, DepartmentId = 1, UniversityStart = Convert.ToDateTime("14.03.2016"), UniversityEnd = Convert.ToDateTime("14.03.2019") });
            resume.EducationInfos.Add(new EducationInfo() { EducationInfoId=1, EducationStatus = EducationStatus.University,UniversityId=2,DepartmentId=2,UniversityStart = Convert.ToDateTime("20.09.2007"),UniversityEnd=Convert.ToDateTime("14.01.2014")});

            resume.Experiences = new List<Experience>();
            resume.Experiences.Add(new Experience() { ExperienceId = 1, CompanyName="Huvitz/TÜRKİYE" ,Title = "İhale-Satış-Aplikasyon Uzmanı",ExperienceStart= Convert.ToDateTime("19.05.2015"), ExperienceEnd=Convert.ToDateTime("15.05.2016"),ExperienceStatus = ExperienceStatus.FullTime,Description="Oftalmoloji Sektöründe Türkiye Distribütörü Firmada Aplikasyon Mühendisi"});

            resume.References = new List<Reference>();
            resume.References.Add(new Reference() { ReferenceId = 1, FirstName = "Hakan", LastName = "YILMAZ", CompanyName = "Bilişim Eğitim Merkezi", Phone = "(0539)-444-1313", EPosta = "hakanyilmaz@gmail.com", Message = "Referans Mesajı Görüntülenecek", ReferenceType = ReferenceType.BusinessFriend ,ReferenceFile="Referans Dosya Uzantısı Olacak",
               SectorId=1 });
         
            resume.SkillInfos = new List<SkillInfo>();
            resume.SkillInfos.Add(new SkillInfo() { SkillInfoId = 1, SkillId = 1, Point = 5 });
          
            resumes.Add(resume);

            return resumes;
             
            
        }

    }
}
