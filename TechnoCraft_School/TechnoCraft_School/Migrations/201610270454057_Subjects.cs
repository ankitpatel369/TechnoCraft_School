namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectAllocation",
                c => new
                    {
                        SubjectAllocation_ID = c.Int(nullable: false, identity: true),
                        Course_ID = c.Int(nullable: false),
                        Standard_ID = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                        Division_ID = c.Int(nullable: false),
                        Employee_ID = c.Int(nullable: false),
                        Subject_ID = c.Int(nullable: false),
                        AllocationDate = c.DateTime(),
                        SubjectAssigns_Subjectassign_ID = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectAllocation_ID)
                .ForeignKey("dbo.SubjectAssign", t => t.SubjectAssigns_Subjectassign_ID)
                .Index(t => t.SubjectAssigns_Subjectassign_ID);
            
            CreateTable(
                "dbo.SubjectAssign",
                c => new
                    {
                        Subjectassign_ID = c.Int(nullable: false, identity: true),
                        Course_ID = c.Int(nullable: false),
                        Standard_ID = c.Int(nullable: false),
                        Subject_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Subjectassign_ID)
                .ForeignKey("dbo.Subjects", t => t.Subject_ID, cascadeDelete: true)
                .Index(t => t.Subject_ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Subject_ID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Subject_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectAllocation", "SubjectAssigns_Subjectassign_ID", "dbo.SubjectAssign");
            DropForeignKey("dbo.SubjectAssign", "Subject_ID", "dbo.Subjects");
            DropIndex("dbo.SubjectAssign", new[] { "Subject_ID" });
            DropIndex("dbo.SubjectAllocation", new[] { "SubjectAssigns_Subjectassign_ID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.SubjectAssign");
            DropTable("dbo.SubjectAllocation");
        }
    }
}
