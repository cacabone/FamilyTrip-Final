using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FamilyTrip.Application.DTOs
{
    public class FamilyMemberDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int TripId { get; set; }
        [Required]
        public string Role { get; set; } 
        public int FamilyId { get; set; } // Added FamilyId property
        public int UserId { get; set; } // Added UserId property for mapping
    }
}
