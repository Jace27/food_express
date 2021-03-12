using System;
using System.Collections.Generic;

namespace food_express.DBEntities
{
    public class OrderDish
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }

        public Order Order { get; set; }
        public Dish Dish { get; set; }
    }
}
