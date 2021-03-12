namespace food_express.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordernumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Number");
        }
    }
}
