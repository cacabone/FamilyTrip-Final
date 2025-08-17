namespace FamilyTrip.Frontend.Models
{
    public class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrganizerId { get; set; }
        public ICollection<int> ParticipantIds { get; set; } = new List<int>();
        public ICollection<int> ItineraryItemIds { get; set; } = new List<int>();
        public ICollection<int> ExpenseIds { get; set; } = new List<int>();
    }
}