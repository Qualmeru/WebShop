namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Products", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Products", name: "ProductName", newName: "Product_name");
            CreateTable(
                "dbo.ProductGenre",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.GenreId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.ProductKonsol",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        KonsolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.KonsolId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Console", t => t.KonsolId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.KonsolId);
            
            AddColumn("dbo.Products", "Year_of_release", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Pic_location", c => c.String());
            AddColumn("dbo.People", "Adress", c => c.String());
            AlterColumn("dbo.Products", "Product_name", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Genre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Genre_Id", c => c.Int());
            DropForeignKey("dbo.ProductKonsol", "KonsolId", "dbo.Console");
            DropForeignKey("dbo.ProductKonsol", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductGenre", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.ProductGenre", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductKonsol", new[] { "KonsolId" });
            DropIndex("dbo.ProductKonsol", new[] { "ProductId" });
            DropIndex("dbo.ProductGenre", new[] { "GenreId" });
            DropIndex("dbo.ProductGenre", new[] { "ProductId" });
            AlterColumn("dbo.Products", "Product_name", c => c.String());
            DropColumn("dbo.People", "Adress");
            DropColumn("dbo.Products", "Pic_location");
            DropColumn("dbo.Products", "Year_of_release");
            DropTable("dbo.ProductKonsol");
            DropTable("dbo.ProductGenre");
            RenameColumn(table: "dbo.Products", name: "Product_name", newName: "ProductName");
            CreateIndex("dbo.Products", "Genre_Id");
            AddForeignKey("dbo.Products", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
