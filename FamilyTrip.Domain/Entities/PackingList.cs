using FamilyTrip.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Domain.Entities
{
    public class PackingList : BaseEntity
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<PackingItem> Items { get; set; }
    }

}
