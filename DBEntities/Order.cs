using System;
using System.Collections.Generic;

namespace food_express.DBEntities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int StatusId { get; set; }

        public ICollection<OrderDish> Dishes { get; set; }
        public OrderStatus Status { get; set; }
    }
}
