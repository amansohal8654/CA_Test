using CA_Test.backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CA_Test.backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<LearningProgress> LearningProgress => Set<LearningProgress>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>(); 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(c => c.Enrollments)
                .WithOne(c => c.Student!)
                .HasForeignKey(c => c.StudentId);

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(c => c.Course!)
                .HasForeignKey(c => c.CourseId);

            modelBuilder
                .Entity<LearningProgress>()
                .HasOne(l => l.Enrollment)
                .WithMany(e => e.LearningProgress)
                .HasForeignKey(l => l.EnrollmentId);

            modelBuilder
                .Entity<Enrollment>()
                .HasMany(e => e.LearningProgress)
                .WithOne(e => e.Enrollment!)
                .HasForeignKey(e => e.EnrollmentId); 
            
        }

    }
}