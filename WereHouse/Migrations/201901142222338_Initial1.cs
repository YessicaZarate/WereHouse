namespace WereHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Item", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Item");
        }
    }
}
