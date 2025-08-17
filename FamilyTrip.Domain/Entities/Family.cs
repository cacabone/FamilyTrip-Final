using FamilyTrip.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Domain.Entities
{
    public class Family : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<FamilyMember> Members { get; set; }
    }

}
