using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.DTOs.ItineraryItem
{
    public class CreateItineraryItemDto
    {
        public int TripId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
