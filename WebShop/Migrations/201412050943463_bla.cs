namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Carts", "GenreId", "dbo.Genres");
            //DropForeignKey("dbo.Carts", "KonsoleId", "dbo.Console");
            //DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            //DropIndex("dbo.Carts", new[] { "ProductId" });
            //DropIndex("dbo.Carts", new[] { "KonsoleId" });
            //DropIndex("dbo.Carts", new[] { "GenreId" });
            //DropTable("dbo.Carts");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Carts", "GenreId");
            CreateIndex("dbo.Carts", "KonsoleId");
            CreateIndex("dbo.Carts", "ProductId");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "KonsoleId", "dbo.Console", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
