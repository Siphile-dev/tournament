using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace TournamentsWebApplication.Models
{
    public class Event
    {
        [Key]

        public int EventID { get; set; }
        public int TournamentID { get; set; }
        public virtual Tournament FK_TournamentID { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Display(Name = "Event Number")]
        public int EventNumber { get; set; }

        [Display(Name = "Event Date Time")]
        public DateTime? EventDateTime { get; set; }

        [Display(Name = "Event End Date Time")]
        public DateTime? EventEndDateTime { get; set; }

        [Display(Name = "Auto Close")]
        public bool AutoClose { get; set; }
        public virtual ICollection<EventDetail> EventDetail { get; set; }


    }

}
