using System;

namespace FamilyTrip.Application.DTOs.Itinerary
{
    public class CreateItineraryDto
    {
        public DateTime Date { get; set; }
        public int TripId { get; set; }
    }
}
