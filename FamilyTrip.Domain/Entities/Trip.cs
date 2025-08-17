using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Core;

namespace FamilyTrip.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int OrganizerId { get; set; }
        public User Organizer { get; set; }

        public ICollection<User> Participants { get; set; }
        public ICollection<Itinerary> Itineraries { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}

