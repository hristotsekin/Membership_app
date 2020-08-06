namespace Membership_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductItemtableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrrodctItem",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ItemId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PrrodctItem");
        }
    }
}
