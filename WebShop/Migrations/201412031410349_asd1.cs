namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd1 : DbMigration
    {
        public override void Up()
        {
           
            //AddColumn("dbo.Carts", "UserId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "UserId", c => c.Int(nullable: false));
        }
    }
}
