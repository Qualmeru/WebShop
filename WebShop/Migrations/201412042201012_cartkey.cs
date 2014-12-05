namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartkey : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Carts", "KonsoleId");
            //RenameColumn(table: "dbo.Carts", name: "Id", newName: "KonsoleId");
            //RenameIndex(table: "dbo.Carts", name: "IX_Id", newName: "IX_KonsoleId");
            //DropPrimaryKey("dbo.Carts");
            //AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Carts", "KeyToken", c => c.String());
            //AlterColumn("dbo.Carts", "UserId", c => c.Int());
            //AddPrimaryKey("dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "KeyToken", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Carts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Carts", new[] { "Id", "KeyToken" });
            RenameIndex(table: "dbo.Carts", name: "IX_KonsoleId", newName: "IX_Id");
            RenameColumn(table: "dbo.Carts", name: "KonsoleId", newName: "Id");
            AddColumn("dbo.Carts", "KonsoleId", c => c.Int(nullable: false));
        }
    }
}
