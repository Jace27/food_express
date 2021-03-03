namespace food_express.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dishname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "Name");
        }
    }
}
