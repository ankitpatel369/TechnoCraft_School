namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        AcademicYear_Id = c.Int(nullable: false, identity: true),
                        AcademicPeriodName = c.String(nullable: false),
                        AcademicPeriodAlias = c.String(nullable: false),
                        StartingDate = c.String(nullable: false),
                        EndingDate = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AcademicYear_Id);
            
            CreateTable(
                "dbo.Admission_Additional_Info",
                c => new
                    {
                        Admission_Additional_Info_ID = c.Int(nullable: false, identity: true),
                        Admission_ID = c.Int(nullable: false),
                        Date_of_Birth = c.DateTime(nullable: false),
                        BirthPlace = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        MotherTongue = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        PermanentCity = c.String(nullable: false),
                        PermanentTaluka = c.String(nullable: false),
                        PermanentDistrict = c.String(nullable: false),
                        PermanentPhone = c.String(nullable: false),
                        LocalAddress = c.String(nullable: false),
                        LocalCity = c.String(nullable: false),
                        LocalTaluka = c.String(nullable: false),
                        LocalDistrict = c.String(nullable: false),
                        LocalPhone = c.String(nullable: false),
                        StudentPhone = c.String(nullable: false),
                        FatherPhone = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        CasteName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Admission_Additional_Info_ID)
                .ForeignKey("dbo.Admissions", t => t.Admission_ID, cascadeDelete: true)
                .Index(t => t.Admission_ID);
            
            CreateTable(
                "dbo.Admissions",
                c => new
                    {
                        Admission_ID = c.Int(nullable: false, identity: true),
                        AcademicYear_ID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        StudentPhoto = c.String(nullable: false),
                        CasteName = c.String(nullable: false),
                        CasteCategory = c.String(nullable: false),
                        Course_ID = c.Int(nullable: false),
                        Standard_ID = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                        Devision_ID = c.Int(nullable: false),
                        Date_Of_Admission = c.DateTime(nullable: false),
                        Year_Of_Admission = c.String(nullable: false),
                        VerificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Admission_ID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Class_ID = c.Int(nullable: false, identity: true),
                        Standard_ID = c.Int(nullable: false),
                        ClassName = c.String(nullable: false),
                        ClassAlias = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Class_ID)
                .ForeignKey("dbo.Standards", t => t.Standard_ID, cascadeDelete: true)
                .Index(t => t.Standard_ID);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Division_ID = c.Int(nullable: false, identity: true),
                        Class_ID = c.Int(nullable: false),
                        DivisionName = c.String(nullable: false),
                        DivisionAlias = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Division_ID)
                .ForeignKey("dbo.Classes", t => t.Class_ID, cascadeDelete: true)
                .Index(t => t.Class_ID);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Standard_ID = c.Int(nullable: false, identity: true),
                        Course_ID = c.Int(nullable: false),
                        StandardName = c.String(nullable: false),
                        StandardAlias = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Standard_ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Course_ID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseAlias = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CourseCode = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Course_ID);
            
            CreateTable(
                "dbo.Institution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstitutionName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        AdminContact = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Currency = c.String(nullable: false),
                        Language = c.String(nullable: false),
                        InstitutionCode = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Students_ID = c.Int(nullable: false, identity: true),
                        GR_No = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        StudentPhoto = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Course_ID = c.Int(nullable: false),
                        Standard_ID = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                        Devision_ID = c.Int(nullable: false),
                        Date_of_Birth = c.DateTime(nullable: false),
                        BirthPlace = c.String(nullable: false),
                        CasteName = c.String(nullable: false),
                        CasteCategory = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        MotherTongue = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        PermanentCity = c.String(nullable: false),
                        PermanentTaluka = c.String(nullable: false),
                        PermanentDistrict = c.String(nullable: false),
                        PermanentPhone = c.String(nullable: false),
                        LocalAddress = c.String(nullable: false),
                        LocalCity = c.String(nullable: false),
                        LocalTaluka = c.String(nullable: false),
                        LocalDistrict = c.String(nullable: false),
                        LocalPhone = c.String(nullable: false),
                        StudentPhone = c.String(nullable: false),
                        FatherPhone = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Date_Of_Admission = c.DateTime(nullable: false),
                        Year_Of_Admission = c.String(nullable: false),
                        Student_Status_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Students_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Standards", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Classes", "Standard_ID", "dbo.Standards");
            DropForeignKey("dbo.Divisions", "Class_ID", "dbo.Classes");
            DropForeignKey("dbo.Admission_Additional_Info", "Admission_ID", "dbo.Admissions");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Standards", new[] { "Course_ID" });
            DropIndex("dbo.Divisions", new[] { "Class_ID" });
            DropIndex("dbo.Classes", new[] { "Standard_ID" });
            DropIndex("dbo.Admission_Additional_Info", new[] { "Admission_ID" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Students");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Institution");
            DropTable("dbo.Courses");
            DropTable("dbo.Standards");
            DropTable("dbo.Divisions");
            DropTable("dbo.Classes");
            DropTable("dbo.Admissions");
            DropTable("dbo.Admission_Additional_Info");
            DropTable("dbo.AcademicYears");
        }
    }
}
