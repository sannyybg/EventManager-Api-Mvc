using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserSideEventManager.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Username { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
    }
}
