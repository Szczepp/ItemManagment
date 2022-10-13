namespace ItemManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
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
                        ItemCollectionId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCollections", t => t.ItemCollectionId)
                .Index(t => t.ItemCollectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemCollectionId", "dbo.ItemCollections");
            DropIndex("dbo.Items", new[] { "ItemCollectionId" });
            DropTable("dbo.Items");
            DropTable("dbo.ItemCollections");
        }
    }
}
