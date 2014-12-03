namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyToken = c.String(),
                        ProductId = c.Int(nullable: false),
                        KonsoleId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        Antal = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Console", t => t.KonsoleId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.KonsoleId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Carts", "KonsoleId", "dbo.Console");
            DropForeignKey("dbo.Carts", "GenreId", "dbo.Genres");
            DropIndex("dbo.Carts", new[] { "GenreId" });
            DropIndex("dbo.Carts", new[] { "KonsoleId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropTable("dbo.Carts");
        }
    }
}
