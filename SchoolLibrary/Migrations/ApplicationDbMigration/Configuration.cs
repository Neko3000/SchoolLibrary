namespace SchoolLibrary.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //these references is significant for role manager and role store
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using SchoolLibrary.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolLibrary.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\ApplicationDbMigration";
            ContextKey = "SchoolLibrary.Models.ApplicationDbContext";
        }

        protected override void Seed(SchoolLibrary.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            if(!context.Roles.Any(r=>r.Name=="SuperAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "SuperAdmin" };
                manager.Create(role);
            }

            if(!context.Users.Any(u=>u.UserName=="founder@live.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "founder@live.com",Email="founder@live.com" };

                manager.Create(user, "Ccxxll333123!");
                manager.AddToRole(user.Id,"SuperAdmin");
            }
        }
    }
}
