using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.DTOs
{
    public class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrganizerId { get; set; }
        public ICollection<int> ParticipantIds { get; set; }
        public ICollection<int> ItineraryItemIds { get; set; }
        public ICollection<int> ExpenseIds { get; set; }
    }
}
