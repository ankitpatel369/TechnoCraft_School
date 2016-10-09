namespace TechnoCraft_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnsDatatype : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Students_ID", c => c.Long(nullable: false));
            AlterColumn("dbo.Students", "GR_No", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Students", new[] { "Students_ID", "GR_No" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "GR_No", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Students_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", new[] { "Students_ID", "GR_No" });
        }
    }
}
