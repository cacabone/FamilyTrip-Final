using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Core;

namespace FamilyTrip.Domain.Entities
{
    public class ItineraryItem : BaseEntity
    {
        public string Activity { get; set; }
        public string Location { get; set; }
        public TimeSpan Time { get; set; }

        public int ItineraryId { get; set; }
        public Itinerary Itinerary { get; set; }
    }
}

