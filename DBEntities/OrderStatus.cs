using System;
using System.Collections.Generic;

namespace food_express.DBEntities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
