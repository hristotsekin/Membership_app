namespace Membership_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateItementitycolumntype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "IsFree", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "IsFree", c => c.Int(nullable: false));
        }
    }
}
