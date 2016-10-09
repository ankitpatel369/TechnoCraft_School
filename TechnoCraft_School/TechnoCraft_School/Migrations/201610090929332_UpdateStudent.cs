namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Date_Of_Admission", c => c.DateTime());
            AlterColumn("dbo.Students", "Year_Of_Admission", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Year_Of_Admission", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Date_Of_Admission", c => c.DateTime(nullable: false));
        }
    }
}
