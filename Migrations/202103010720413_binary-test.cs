namespace food_express.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class binarytest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DishCategories", "ImageFileName", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DishCategories", "ImageFileName", c => c.String());
        }
    }
}
