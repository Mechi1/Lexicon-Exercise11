namespace Exercise11_Inventory_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestockLimit_FirstAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "RestockLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "RestockLimit");
        }
    }
}
