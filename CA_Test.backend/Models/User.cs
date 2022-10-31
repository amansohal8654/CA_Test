using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CA_Test.backend.Models
{
public class User
{
    public int Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public Role Role { get; set; }
    [Required]
    public DateTime RegistrationDate { get; set; }
    [Required]
    public int NumberOfCoursesEnrolled { get; set; }
    [Required]
    public int NumberOfCoursesCompleted { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    [JsonIgnore]
    public string? PasswordHash { get; set; }
}
}