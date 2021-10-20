using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class EventServiceModel
    {
        
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public bool isPublished { get; set; } = false;

        public UserServiceModel User { get; set; }

        public int UserId { get; set; }

        public string PhotoUrl { get; set; }
    }
}
