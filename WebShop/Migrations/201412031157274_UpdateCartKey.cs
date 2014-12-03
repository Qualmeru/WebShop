namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Konsol_Id", "dbo.Console");
            DropIndex("dbo.Carts", "IX_Konsol_Id");
            DropColumn("dbo.Carts", "Konsol_Id");
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Carts", "KeyToken", c => c.String());
            AddPrimaryKey("dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "KeyToken", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Carts", new[] { "Id", "KeyToken" });
            RenameIndex(table: "dbo.Carts", name: "IX_KonsoleId", newName: "IX_Id");
            RenameColumn(table: "dbo.Carts", name: "KonsoleId", newName: "Id");
            AddColumn("dbo.Carts", "KonsoleId", c => c.Int(nullable: false));
        }
    }
}
