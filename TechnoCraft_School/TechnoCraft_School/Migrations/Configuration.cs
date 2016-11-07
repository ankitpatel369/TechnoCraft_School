namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using TechnoCraft_School.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //try
            //{
            //    context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Global Admin"
            //    });

            //    context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Admin"
            //    });
                
            //    context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Faculty"
            //    });

            //    context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Student"
            //    });
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation(
            //                  "Class: {0}, Property: {1}, Error: {2}",
            //                  validationErrors.Entry.Entity.GetType().FullName,
            //                  validationError.PropertyName,
            //                  validationError.ErrorMessage);
            //        }
            //    }
            //}
        }
    }
}
