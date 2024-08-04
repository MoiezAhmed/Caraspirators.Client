
namespace Caraspirator.Library.Models.DTO;

public class CategoryDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int categoryid { get; set; }
    public string? CategoryName { get; set; }

    public string? categoryimage { get; set; }
    public int parentid { get; set; }
    public bool isactive { get; set; }
    public string? slug { get; set; }
    public DateTime createdat { get; set; }

    public DateTime updatedat { get; set; }

    public string? status { get; set; }
}
