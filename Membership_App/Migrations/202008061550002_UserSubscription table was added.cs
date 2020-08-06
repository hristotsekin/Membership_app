namespace Membership_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSubscriptiontablewasadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSubscription",
                c => new
                    {
                        SubstrictionId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SubstrictionId, t.UserId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSubscription");
        }
    }
}
