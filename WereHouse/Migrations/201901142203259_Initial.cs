namespace WereHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Description = c.String(),
                        Qty = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Country = c.String(),
                        Provider = c.String(),
                        Warranty = c.Int(nullable: false),
                        DateAd = c.DateTimeOffset(precision: 7),
                        DateCr = c.DateTimeOffset(precision: 7),
                        DateUp = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
