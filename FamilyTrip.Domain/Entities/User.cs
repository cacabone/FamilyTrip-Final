using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Core;

namespace FamilyTrip.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Trip> OrganizedTrips { get; set; }
        public ICollection<Trip> ParticipatingTrips { get; set; }
    }
}

