namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student_Status",
                c => new
                    {
                        Student_Status_ID = c.Int(nullable: false, identity: true),
                        StudentStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Student_Status_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student_Status");
        }
    }
}
