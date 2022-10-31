using System.ComponentModel.DataAnnotations;

namespace CA_Test.backend.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? CourseTitle { get; set; }
        [Required]
        public string? CourseDescription { get; set; }
        [Required]
        public int InstructorId { get; set; }
        [Required]
        public int NumberOfModules { get; set; }
        [Required]
        public decimal? CourseFee { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}