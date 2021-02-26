namespace food_express
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using food_express.DBEntities;

    public partial class MainModel : DbContext
    {
        public MainModel() : base("name=MainModel")
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishCategories> DishesCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
