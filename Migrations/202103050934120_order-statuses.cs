namespace food_express.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderstatuses : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.OrderStatuses", "OrderStatus");
        }
        
        public override void Down()
        {
            RenameTable("dbo.OrderStatus", "dbo.OrderStatuses");
        }
    }
}
