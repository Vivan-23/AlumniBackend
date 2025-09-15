using AlumniBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniBackend.DATA

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventRegistration> EventsRegistration { get; set; }
        public DbSet<AlumniProfile> AlumniProfiles { get; set; }
        public DbSet<MentorshipRequest> MentorshipRequests { get; set; }
        public DbSet<Donation> Donations { get; set; }  
        public DbSet<Roles> Roles { get; set; }
    }
}