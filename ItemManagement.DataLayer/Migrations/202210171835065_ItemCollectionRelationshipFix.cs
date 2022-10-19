namespace ItemManagement.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCollectionRelationshipFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCollections",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Tag = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemItemCollections",
                c => new
                    {
                        Item_Id = c.Long(nullable: false),
                        ItemCollection_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.ItemCollection_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.ItemCollections", t => t.ItemCollection_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.ItemCollection_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemItemCollections", "ItemCollection_Id", "dbo.ItemCollections");
            DropForeignKey("dbo.ItemItemCollections", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemItemCollections", new[] { "ItemCollection_Id" });
            DropIndex("dbo.ItemItemCollections", new[] { "Item_Id" });
            DropTable("dbo.ItemItemCollections");
            DropTable("dbo.Items");
            DropTable("dbo.ItemCollections");
        }
    }
}
