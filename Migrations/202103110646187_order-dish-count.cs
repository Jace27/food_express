namespace food_express.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderdishcount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDishes", "Count", c => c.Int(defaultValue: 1, nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDishes", "Count");
        }
    }
}
