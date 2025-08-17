using System.ComponentModel.DataAnnotations;

namespace FamilyTrip.Application.DTOs
{
    public class CreateFamilyDto
    {
        [Required]
        public string Name { get; set; }
    }
}
