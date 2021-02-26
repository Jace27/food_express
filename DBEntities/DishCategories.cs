using System;
using System.Collections.Generic;

namespace food_express.DBEntities
{
    public class DishCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFileName { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
