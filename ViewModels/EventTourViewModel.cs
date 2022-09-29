using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentsWebApplication.Models;

namespace TournamentsWebApplication.ViewModels
{
    public class EventTourViewModel
    {
        public Tournament Tournament { get; set; }
       
        public IEnumerable<Event> Event { get; set; }
        public bool AutoClose { get; internal set; }
    }
}
