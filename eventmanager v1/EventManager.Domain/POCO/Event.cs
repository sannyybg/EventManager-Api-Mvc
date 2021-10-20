using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Domain.POCO
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public bool isPublished { get; set; } = false;

        public User User { get; set; }

        public int UserId { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool ChangePossibility { get; set; } = false;

        public bool isAchieved { get; set; } = false;

        public string PhotoUrl { get; set; }


    }
}
