namespace Membership_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Itemtableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 2048),
                        Url = c.String(maxLength: 1024),
                        ImageUrl = c.String(maxLength: 1024),
                        HTML = c.String(),
                        WaitDays = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ItemTypeId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        IsFree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ItemType", "Item_Id", c => c.Int());
            AddColumn("dbo.Part", "Item_Id", c => c.Int());
            AddColumn("dbo.Section", "Item_Id", c => c.Int());
            CreateIndex("dbo.ItemType", "Item_Id");
            CreateIndex("dbo.Part", "Item_Id");
            CreateIndex("dbo.Section", "Item_Id");
            AddForeignKey("dbo.ItemType", "Item_Id", "dbo.Item", "Id");
            AddForeignKey("dbo.Part", "Item_Id", "dbo.Item", "Id");
            AddForeignKey("dbo.Section", "Item_Id", "dbo.Item", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Section", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.Part", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.ItemType", "Item_Id", "dbo.Item");
            DropIndex("dbo.Section", new[] { "Item_Id" });
            DropIndex("dbo.Part", new[] { "Item_Id" });
            DropIndex("dbo.ItemType", new[] { "Item_Id" });
            DropColumn("dbo.Section", "Item_Id");
            DropColumn("dbo.Part", "Item_Id");
            DropColumn("dbo.ItemType", "Item_Id");
            DropTable("dbo.Item");
        }
    }
}
