namespace FamilyTrip.Frontend.Models
{
    public class PackingItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPacked { get; set; }
        public int PackingListId { get; set; }
    }
}