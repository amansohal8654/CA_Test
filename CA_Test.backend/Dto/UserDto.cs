using System.ComponentModel.DataAnnotations;

namespace CA_Test.backend.Dto
{
    public class UserDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}