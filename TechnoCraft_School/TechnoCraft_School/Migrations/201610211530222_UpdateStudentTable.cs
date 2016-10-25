namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Students_ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "Students_ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Students_ID", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Students", new[] { "Students_ID", "GR_No" });
        }
    }
}
