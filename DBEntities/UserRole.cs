using System;
using System.Collections.Generic;

namespace food_express.DBEntities
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
