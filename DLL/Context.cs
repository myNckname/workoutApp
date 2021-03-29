using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<UserWorkout> UsersWorkouts { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Statistics>()
                .HasOne(c => c.User)
                .WithMany(p => p.Statistics)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}