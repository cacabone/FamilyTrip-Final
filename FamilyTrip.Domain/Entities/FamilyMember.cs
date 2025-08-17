using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Core;

namespace FamilyTrip.Domain.Entities
{
    public class FamilyMember : BaseEntity
    {
        public int FamilyId { get; set; }
        public Family Family { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Role { get; set; } // Ej: "Padre", "Hijo", etc.
    }
}

