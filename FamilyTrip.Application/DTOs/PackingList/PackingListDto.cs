using System.Collections.Generic;

namespace FamilyTrip.Application.DTOs.PackingList
{
    public class PackingListDto
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }
        public List<PackingItemDto> Items { get; set; }
    }
}