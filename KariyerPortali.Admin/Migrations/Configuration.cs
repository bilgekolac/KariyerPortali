namespace KariyerPortali.Admin.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KariyerPortali.Admin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KariyerPortali.Admin.Models.ApplicationDbContext";
        }

        protected override void Seed(KariyerPortali.Admin.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "SubAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "SubAdmin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Aday"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Aday" };
                manager.Create(role);
            }
            if (!context.Users.Any(u => u.Email == "kariyerportali@gmail.com"))
            {
                var password = "Admin123+";
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "kariyerportali@gmail.com", Email = "kariyerportali@gmail.com", EmailConfirmed = true, FirstName = "Admin", LastName = "Root", CreatedDate = DateTime.Now, ImagePath = "kariyerportaliAdminDefault.png" };
                //manager.Create(user, password);
                var result = manager.Create(user, password);
                if (result.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
