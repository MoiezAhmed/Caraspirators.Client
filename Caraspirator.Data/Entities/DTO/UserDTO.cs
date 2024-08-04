
namespace Caraspirator.Data.Entities.DTO;
public class UserDTO
{
    [Key]
    public int userId { get; set; }
    [Required]
    public string username { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string passwordHash { get; set; }
    [Required]
    public string firstName { get; set; }
    [Required]
    public string lastName { get; set; }
    [Required]
    public DateTime dateRegistered { get; set; }
    [Required]
    public DateTime lastLogin_Date { get; set; }

    public string status { get; set; }
}
