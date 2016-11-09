using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KariyerPortali.Admin.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Görev")]
        public string Title { get; set; }
        [Display(Name = "Görsel")]
        public string ImagePath { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }

    }

    public class ApplicationRole:IdentityRole
    {
        
        public ApplicationRole()
        {

        }
        

        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }

        public ApplicationRole(string roleName,string description):base(roleName)
        {
            this.Description = description;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, KariyerPortali.Admin.Migrations.Configuration>
                ("DefaultConnection"));
        }
        public static ApplicationDbContext Create()
        {
           
            return new ApplicationDbContext();
        }
    }
}