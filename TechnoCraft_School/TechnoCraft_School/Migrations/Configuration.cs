namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TechnoCraft_School.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechnoCraft_School.Models.ApplicationDbContext context)
        {
            try
            {
                //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                //{
                //    Name = "Global Admin"
                //});

                //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                //{
                //    Name = "Agent"
                //});

                //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                //{
                //    Name = "User"
                //});
                //context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                              "Class: {0}, Property: {1}, Error: {2}",
                              validationErrors.Entry.Entity.GetType().FullName,
                              validationError.PropertyName,
                              validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
