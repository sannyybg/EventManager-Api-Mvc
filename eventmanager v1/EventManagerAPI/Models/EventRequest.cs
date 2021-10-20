using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerAPI.Models
{
    public class EventRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        //public bool isPublished { get; set; } = false;

        //public UserRequest User { get; set; }

        public int UserId { get; set; }

        public string PhotoUrl { get; set; }
    }
}
