using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerAPI.Models
{
    public class EventAdminPut
    {
        public int Id { get; set; }

        public bool isPublished { get; set; } = false;

        public int UserId { get; set; }

        public DateTime ModifiedDate { get; set; }




    }
}
