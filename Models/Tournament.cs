using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace TournamentsWebApplication.Models
{
    public class Tournament
    {
        public int TournamentID { get; set; }

        [Display(Name = "Tournament Name")]
        public string TournamentName { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public Tournament()
        {

        }
    }
}
