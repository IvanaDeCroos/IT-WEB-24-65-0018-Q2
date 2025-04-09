using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary keys
            modelBuilder.Entity<Course>().HasKey(c => c.CourseId);
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);

            // Configure the relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId);

            // Seed data for courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Name = "Web Development", LecturerName = "M.M. Herath" },
                new Course { CourseId = 2, Name = "Graphic Design", LecturerName = "J.S.V. Piyasena" },
                new Course { CourseId = 3, Name = "Mobile App Development", LecturerName = "K.K.S. Dias" },
                new Course { CourseId = 4, Name = "Java", LecturerName = "U.H.S. Perera" }
            );

            // Seed data for students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Kasun Gamage", City = "Kandy", CourseId = 2 },
                new Student { StudentId = 2, Name = "Daniel Sam", City = "Jaffna", CourseId = 3 },
                new Student { StudentId = 3, Name = "Hansi Silva", City = "Colombo", CourseId = 1 },
                new Student { StudentId = 4, Name = "Ranidu Heath", City = "Matara", CourseId = 3 },
                new Student { StudentId = 5, Name = "Praneeth Wijesinghe", City = "Kandy", CourseId = 4 },
                new Student { StudentId = 6, Name = "Nuwani Herath", City = "Rathnapura", CourseId = 1 }
            );
        }
    }
}
