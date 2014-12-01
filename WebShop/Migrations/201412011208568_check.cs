namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Carts", name: "IX_Id", newName: "IX_KonsoleId");
            RenameColumn(table: "dbo.Carts", name: "Id", newName: "KonsoleId");
            AddColumn("dbo.Carts", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "UserId");
            AddForeignKey("dbo.Carts", "UserId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
