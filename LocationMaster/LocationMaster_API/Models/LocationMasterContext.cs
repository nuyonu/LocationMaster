using LocationMaster_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocationMaster_API.Models
{
    public class LocationMasterContext : DbContext
    {
        public LocationMasterContext(DbContextOptions<LocationMasterContext> options) : base(options)
        {
            /*Database.EnsureCreated();*/
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
