namespace food_express.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class binary : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.DishCategories", "ImageFileName", "Image");
            DropColumn("dbo.Dishes", "ImageFileName");
            AddColumn("dbo.Dishes", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "Image");
            AddColumn("dbo.Dishes", "ImageFileName", c => c.String());
            RenameColumn("dbo.DishCategories", "Image", "ImageFileName");
        }
    }
}
