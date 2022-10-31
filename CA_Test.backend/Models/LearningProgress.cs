using System.ComponentModel.DataAnnotations;

namespace CA_Test.backend.Models
{
    public class LearningProgress
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int EnrollmentId { get; set; }
        [Required]
        public int CourseChapterContentId { get; set; }
        [Required]
        public DateTime BeginTimestamp { get; set; }
        [Required]
        public DateTime CompletionTimestamp { get; set; }
        [Required]
        public Status Status { get; set; }
        public Enrollment? Enrollment { get; set; }
        
    }

    public enum Status
    {
        Active,
        Hold,
    }
}