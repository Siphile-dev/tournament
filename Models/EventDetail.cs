using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentsWebApplication.Models
{
    public class EventDetail
    {
        public int EventDetailID { get; set; }
        public int EventID { get; set; }
        public virtual Event FK_EventID { get; set; }
        public int EventDetailStatusID { get; set; }

        public virtual EventDetailStatus FK_EventDetailStatusID { get; set; }

        [Display(Name = "Event Detail Name")]
        public string EventDetailName { get; set; }

        [Display(Name = "Event Detail Number")]
        public int EventDetailNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Event Detail Odd")]
        public decimal EventDetailOdd { get; set; }

        [Display(Name = "Finishing Position")]
        public int FinishingPosition { get; set; }

        [Display(Name = "First Timer")]
        public bool FirstTimer { get; set; }

    }
}
