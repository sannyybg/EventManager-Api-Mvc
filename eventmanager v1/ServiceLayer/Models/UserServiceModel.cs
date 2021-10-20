using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class UserServiceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<EventServiceModel> Events { get; set; }
        public bool isAdmin { get; set; } = false;

        public string Token { get; set; }
    }
}
