using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApplication.Models
{
    public class EventDetailStatus
    {
        public int EventDetailStatusID { get; set; }

        [Display(Name = "Event Detail Status")]
        public string EventDetailStatusName { get; set; }
        public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
