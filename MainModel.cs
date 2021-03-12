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
        public DbSet<DishCategory> DishesCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
