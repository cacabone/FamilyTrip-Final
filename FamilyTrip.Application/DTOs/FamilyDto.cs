using System.ComponentModel.DataAnnotations;

namespace FamilyTrip.Application.DTOs
{
    public class FamilyDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
