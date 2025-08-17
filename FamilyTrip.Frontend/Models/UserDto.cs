namespace FamilyTrip.Frontend.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<int> OrganizedTripIds { get; set; } = new List<int>();
        public ICollection<int> ParticipatingTripIds { get; set; } = new List<int>();
    }
}