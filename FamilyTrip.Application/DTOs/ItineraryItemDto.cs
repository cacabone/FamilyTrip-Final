using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.DTOs
{
    public class ItineraryItemDto
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public int TripId { get; set; }
        public int ItineraryId { get; set; } // Added to support mapping and FK constraint
    }
}
