using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Core;

namespace FamilyTrip.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int PayerId { get; set; }
        public User Payer { get; set; }
    }
}
