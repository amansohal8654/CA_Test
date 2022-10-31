using CA_Test.backend.Models;

namespace CA_Test.backend.Dto;

public class LoginResponse
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }
    public string Token { get; set; }

    public LoginResponse(User user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Role = user.Role;
        Token = token;
    }
}