using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Core;

namespace FamilyTrip.Domain.Entities
{
    public class PackingItem : BaseEntity
    {
        public string Name { get; set; }
        public bool IsPacked { get; set; }

        public int PackingListId { get; set; }
        public PackingList PackingList { get; set; }
    }
}
