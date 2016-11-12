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
           
            GetCandidates().ForEach(c => context.Candidates.Add(c));
            GetHighSchoolTypes().ForEach(c => context.HighSchollTypes.Add(c));
            GetHighSchoolDeparments().ForEach(c => context.HighSchollDepartments.Add(c));
            GetCountries().ForEach(c => context.Countries.Add(c));
            GetCities().ForEach(c => context.Cities.Add(c));
            GetLanguages().ForEach(c => context.Languages.Add(c));
            //GetResumes().ForEach(c => context.Resumes.Add(c));


            context.Commit();
        }
        private static List<Candidate> GetCandidates()
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
                    Photo= null,
                    CreateDate =DateTime.Now,
                    State =true,
                    UpdatedBy= "muhammed",
                    UpdatedDate=DateTime.Now,

                },

            };
        }
        private static List<HighSchoolType> GetHighSchoolTypes()
        {
            return new List<HighSchoolType>
            {
                new HighSchoolType{

                    HighSchoolTypeId =1,
                    TypeName="Anadolu Lisesi",

                },

            };
        }
        private static List<HighSchoolDepartment> GetHighSchoolDeparments()
        {
            return new List<HighSchoolDepartment>
            {
                new HighSchoolDepartment {
                    HighSchoolDepartmentId=1,
                    DepartmentName="Sayısal",
                },

            };
        }
        private static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country {
                    CountryId=1,
                    CountryName="Türkiye",

                },

            };
        }
        private static List<City> GetCities()
        {
            return new List<City>
            {
                new City {

                    CityId =1,
                    CityName="İstanbul",
         
               
                    
                },

            };
        }
        private static List<Language> GetLanguages()
        {
            return new List<Language>
            {
                new Language {
                    LanguageId=1,
                    LanguageName="İngilizce",

                },

            };
        }
        private static List<Resume> GetResumes()
        {
            return new List<Resume>
            {
                new Resume {
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
                    CellPhone="(0539)6454545",
                    CellPhone2="(0505)4441444",
                    HomePhone="(0212)4441111",
                    Website="www.muhammedsezgin.wordpress.com",
                    Address="Bahçeşehir/İSTANBUL",
                    HighSchoolName="Bahçeşehir Atatürk Anadolu Lisesi",
                    ComputerSkill="C#, Matlab , PhotoShop, AutoCAD ,SQL Server",
                    Certificate="İŞKUR Yazılım Sertifikası",
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
                    CandidateId=1,
                    LanguageId=1,
                    Gender = Gender.Male,
                    BirthCity= new City() {CityId=1 },
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
                    CertificateDegree= 3,
                    BloodType = BloodType.ARhP,
                    CigaretteStatus = CigaretteStatus.Yes,
                    SalaryWaited = SalaryWaited.B3000and4000,

                  
                    
                    
                },
                
            };
        }

    }
}
