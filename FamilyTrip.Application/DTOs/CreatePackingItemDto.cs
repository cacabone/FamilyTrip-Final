using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.DTOs.PackingList
{
    public class CreatePackingItemDto
    {
        public string Name { get; set; }  
        public int Quantity { get; set; } 
        public bool IsPacked { get; set; } 
    }
}

