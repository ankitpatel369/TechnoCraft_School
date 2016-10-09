using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TechnoCraftSchool_Model;

namespace TechnoCraft_School.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public string AvtarProfile { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("School", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            return new ApplicationDbContext();
        }

        /*Institute Models*/
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }

        /*Academic Models*/
        public DbSet<Course> Courses { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Class> Classes { get; set; }

        /*Student*/
        public DbSet<Students> Students { get; set; }
        public DbSet<Student_Status> Student_Status { get; set; }

        /*Admission Models*/
        public DbSet<Admissions> Admissions { get; set; }
        public DbSet<Admission_Additional_Info> Admission_Additional_Infos { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Institute>().ToTable("Institution", "dbo");
            modelBuilder.Entity<AcademicYear>().ToTable("AcademicYears", "dbo");

            modelBuilder.Entity<Course>().ToTable("Courses", "dbo");
            modelBuilder.Entity<Standard>().ToTable("Standards", "dbo");
            modelBuilder.Entity<Division>().ToTable("Divisions", "dbo");
            modelBuilder.Entity<Class>().ToTable("Classes", "dbo");
            modelBuilder.Entity<Students>().ToTable("Students", "dbo");

            modelBuilder.Entity<Admissions>().ToTable("Admissions", "dbo");
            modelBuilder.Entity<Admission_Additional_Info>().ToTable("Admission_Additional_Info", "dbo");

            modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo");

            //Course -> Standard one to many relation
            modelBuilder.Entity<Course>().HasMany(c => c.Standards).WithRequired(c => c.Course);//.WillCascadeOnDelete();

            //Standard -> Division one to many relation
            modelBuilder.Entity<Standard>().HasMany(s => s.Classes).WithRequired(s => s.Standards);//.WillCascadeOnDelete();

            //Classes -> Batch one to many relation
            modelBuilder.Entity<Class>().HasMany(c => c.Divisions).WithRequired(c => c.Classs);//.WillCascadeOnDelete();

        }

    }
}