namespace ProductManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "ProductId", c => c.Int(nullable: false));
        }
    }
}
