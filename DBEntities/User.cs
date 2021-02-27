using System;
using System.Collections.Generic;

namespace food_express.DBEntities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public UserRole Role { get; set; }
    }
}
