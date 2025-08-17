using FamilyTrip.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Domain.Entities
{
    public class Itinerary : BaseEntity
    {
        public DateTime Date { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public ICollection<ItineraryItem> Items { get; set; }
    }

}
