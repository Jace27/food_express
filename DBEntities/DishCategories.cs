using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace food_express.DBEntities
{
    public class DishCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
