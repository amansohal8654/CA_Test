using System.ComponentModel.DataAnnotations;

namespace CA_Test.backend.Models
{
    public class Enrollment
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        public bool IsPaidSubscribe { get; set; }
        public Course? Course { get; set; }
        public User? Student { get; set; }
        public ICollection<LearningProgress> LearningProgress { get; set; } = new List<LearningProgress>();
    }
}