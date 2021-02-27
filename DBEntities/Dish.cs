using System;
using System.Collections.Generic;

namespace food_express.DBEntities
{
    public class Dish
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int CategoryId { get; set; }
        public string ImageFileName { get; set; }

        public DishCategories Category { get; set; }
        public ICollection<OrderDish> Orders { get; set; }
    }
}
