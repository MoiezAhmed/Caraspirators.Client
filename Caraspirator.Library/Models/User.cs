

namespace Caraspirator.Library.Models;

public class User
{
    [Key] 
    public int UserId { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? PasswordHash { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public DateTime DateRegistered { get; set; }
    [Required]
    public DateTime LastLogin_Date { get; set; }

    public bool IsActive { get; set; }

  
}
