using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace food_express.DBEntities
{
    public class Order
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public string Number { get; set; }
        public DateTime DateTime { get; set; }
        public int StatusId { get; set; }

        public ICollection<OrderDish> Dishes { get; set; }
        public OrderStatus Status { get; set; }
    }
}
