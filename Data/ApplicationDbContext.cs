using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTelerikProject.Models;


namespace MyTelerikProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OverTimeRequest> OverTimeRequests { get; set; }
        //public DbSet<Stations> Stations { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Station> Stations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<OverTimeRequest>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OverTimeRequest>()
                .HasOne(o => o.User)
                .WithMany(u => u.OverTimeRequests)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, employeeNumber = 123456, firstName = "John", lastName = "Doe" },
                new User { Id = 2, employeeNumber = 234567, firstName = "Jane", lastName = "Smith" }
            );

            modelBuilder.Entity<OverTimeRequest>().HasData(
                new OverTimeRequest { Id = 1, employeeNumber = 123456, dateRequested = new DateTime(2023, 1, 20), dateCreated = DateTime.Now, hasBeenAssigned = false, assignedToStation = "S1", UserId = 1 },
                new OverTimeRequest { Id = 2, employeeNumber = 234567, dateRequested = new DateTime(2023, 2, 10), dateCreated = DateTime.Now, hasBeenAssigned = true, assignedToStation = "S2", UserId = 2 }
            );
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}