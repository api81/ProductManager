namespace ProductManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "OrderDeliveryDeadlineDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "OrderStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "OrderStatus");
            DropColumn("dbo.Order", "OrderDeliveryDeadlineDate");
        }
    }
}
