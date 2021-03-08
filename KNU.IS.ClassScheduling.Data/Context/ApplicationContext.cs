using KNU.IS.ClassScheduling.Data.Configuration;
using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KNU.IS.ClassScheduling.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TimePeriod> TimePeriods { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        }

    }
}
