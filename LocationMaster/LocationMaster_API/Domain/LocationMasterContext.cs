using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocationMaster_API.Domain
{
    public class LocationMasterContext : DbContext
    {
        public LocationMasterContext(DbContextOptions<LocationMasterContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                // Make sure the base is called
              base.OnModelCreating(modelBuilder);

              // Call our data seeder
              SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // NOTE: We use ".HasData" here, this means this data will ONLY be seeded IF the table
            // is completley empty.

            const string usernameAdmin = "admin";
            var passwordAdmin = SecurePasswordHasherHelperService.Hash("admin");
            const string emailAdmin = "admin@gmail.com";
            const string lastNameAdmin = "Gigica";
            const string firstNameAdmin = "Comanel";
            var allowedRolesAdmin = new[] { "admin"};
            var birthDate = DateTime.Now;
            var defaultProfileImageAdmin = Photo.Create("/StaticFiles/Images/ProfileImages/DefaultProfileImage.png");
            var userAdmin = User.Create(usernameAdmin, passwordAdmin, emailAdmin, lastNameAdmin, firstNameAdmin, birthDate, allowedRolesAdmin);
            //userAdmin.SetProfileImage(defaultProfileImageAdmin);

            const string usernameModerator = "moderator";
            var passwordModerator = SecurePasswordHasherHelperService.Hash("moderator");
            const string emailModerator = "moderator@gmail.com";
            const string lastNameModerator = "Jhony";
            const string firstNameModerator = "Comanel";
            var allowedRolesModerator = new[] { "moderator" };
            var defaultProfileImageModerator = Photo.Create("/StaticFiles/Images/ProfileImages/DefaultProfileImage.png");
            var userModerator = User.Create(usernameModerator, passwordModerator, emailModerator, lastNameModerator, firstNameModerator, birthDate, allowedRolesModerator);
            //userModerator.SetProfileImage(defaultProfileImageModerator);

            const string usernameNormalUser = "user";
            var passwordNormalUser = SecurePasswordHasherHelperService.Hash("user");
            const string emailNormalUser = "user@gmail.com";
            const string lastNameNormalUser = "Florinel";
            const string firstNameNormalUser = "Comanel";
            var allowedRolesNormalUser = new[] { "user" };
            var defaultProfileImageNormalUser = Photo.Create("/StaticFiles/Images/ProfileImages/DefaultProfileImage.png");
            var userNormalUser = User.Create(usernameNormalUser, passwordNormalUser, emailNormalUser, lastNameNormalUser, firstNameNormalUser, birthDate, allowedRolesNormalUser);
            //userNormalUser.SetProfileImage(defaultProfileImageNormalUser);

            modelBuilder.Entity<Photo>()
                  .HasData(
                    defaultProfileImageAdmin,
                    defaultProfileImageModerator,
                    defaultProfileImageNormalUser
                 );

            modelBuilder.Entity<User>()
              .HasData(
                userAdmin,
                userModerator,
                userNormalUser
             );
        }
    }
}
