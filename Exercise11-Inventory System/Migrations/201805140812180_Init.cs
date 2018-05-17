namespace Exercise11_Inventory_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 63),
                        Price = c.Int(nullable: false),
                        Category = c.String(nullable: false, maxLength: 63),
                        Shelf = c.String(nullable: false, maxLength: 63),
                        Count = c.Int(nullable: false),
                        Description = c.String(maxLength: 1023),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
