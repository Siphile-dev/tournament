using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentsWebApplication.Models;

namespace TournamentsWebApplication.ViewModels
{
    public class EventEventdetailsViewModel
    {

        public Event Event { get; set; }

        public IEnumerable<EventDetail> EventDetail { get; set; }

        public IEnumerable<EventDetailStatus> EventDetailStatus { get; set; }
        public bool FirstTimer { get; internal set; }
    }
}
