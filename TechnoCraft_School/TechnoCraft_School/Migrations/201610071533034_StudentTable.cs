namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Division_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Devision_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Devision_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Division_ID");
        }
    }
}
