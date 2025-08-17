using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FamilyTrip.Domain.Entities;

namespace FamilyTrip.Infrastructure.Context
{
    public class FamilyTripDbContext : DbContext
    {
        public FamilyTripDbContext(DbContextOptions<FamilyTripDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ItineraryItem> ItineraryItems { get; set; }
        public DbSet<PackingItem> PackingItems { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Family> Family { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación uno a muchos: Organizer
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Organizer)
                .WithMany(u => u.OrganizedTrips)
                .HasForeignKey(t => t.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos: Participantes
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Participants)
                .WithMany(u => u.ParticipatingTrips)
                .UsingEntity(j => j.ToTable("TripParticipants"));
        }
    }
}
