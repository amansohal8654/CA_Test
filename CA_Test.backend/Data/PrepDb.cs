using CA_Test.backend.Models;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace CA_Test.backend.Data
{
    public class PrepDb 
    {  
        public static void PrePopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Users.Any())
            {
                Console.WriteLine("---> Seeding User Data");

                context.Users.AddRange(
                    new User() {Id = 1, FirstName = "Admin", LastName = "Singh", Email = "Admin@example.com", PasswordHash = BCryptNet.HashPassword("admin"), Role = Role.Admin},
                    new User() {Id = 2, FirstName = "Aman", LastName = "Singh", Email = "Aman@example.com", PasswordHash = BCryptNet.HashPassword("12345678"), Role = Role.User},
                    new User() {Id = 3, FirstName = "Amandeep", LastName = "Singh", Email = "Amansec@example.com", PasswordHash = BCryptNet.HashPassword("qwerty"), Role = Role.User}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have User data");
            }

            if(!context.Courses.Any())
            {
                Console.WriteLine("---> Seeding Course Data");
                context.Courses.AddRange(
                    new Course() {Id = 1, CourseTitle = "Xero", CourseDescription = "certificate in Xero", InstructorId = 1, NumberOfModules = 8, CourseFee = 100},
                    new Course() {Id = 2, CourseTitle = "bookkeeping", CourseDescription = "certificate in bookkeeping", InstructorId = 1, NumberOfModules = 8, CourseFee = 100},
                    new Course() {Id = 3, CourseTitle = "psychology", CourseDescription = "certificate in psychology plus generic prices", InstructorId = 1, NumberOfModules = 8, CourseFee = 100}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have Course data");
            }

            if(!context.Enrollments.Any())
            {
                Console.WriteLine("---> Seeding Enrollment Data");
                context.Enrollments.AddRange(
                    new Enrollment() {Id = 1, StudentId = 2, CourseId = 1, EnrollmentDate = DateTime.Now},
                    new Enrollment() {Id = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now},
                    new Enrollment() {Id = 3, StudentId = 3, CourseId = 1, EnrollmentDate = DateTime.Now},
                    new Enrollment() {Id = 4, StudentId = 3, CourseId = 2, EnrollmentDate = DateTime.Now}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have Enrollment data");
            }

            if(!context.LearningProgress.Any())
            {
                Console.WriteLine("---> Seeding Learning Progress Data");
                context.LearningProgress.AddRange(
                    new LearningProgress() {Id = 1, EnrollmentId = 1, CourseChapterContentId = 1, BeginTimestamp = DateTime.Now, CompletionTimestamp = DateTime.Now.AddYears(1), Status = Status.Active},
                    new LearningProgress() {Id = 2, EnrollmentId = 2, CourseChapterContentId = 2, BeginTimestamp = DateTime.Now, CompletionTimestamp = DateTime.Now.AddYears(1), Status = Status.Active},
                    new LearningProgress() {Id = 3, EnrollmentId = 3, CourseChapterContentId = 1, BeginTimestamp = DateTime.Now, CompletionTimestamp = DateTime.Now.AddYears(1), Status = Status.Active},
                    new LearningProgress() {Id = 4, EnrollmentId = 4, CourseChapterContentId = 2, BeginTimestamp = DateTime.Now, CompletionTimestamp = DateTime.Now.AddYears(1), Status = Status.Active}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have Learning Progress data");
            }

        }
    }
}