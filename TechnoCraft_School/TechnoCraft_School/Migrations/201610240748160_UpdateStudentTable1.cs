namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentPhoto", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentPhoto", c => c.String(nullable: false));
        }
    }
}
