
using Caraspirator.Data.Commons;
using Caraspirator.Data.Entities.DTO;

namespace Caraspirator.Data.Entities;

public class Category: GeneralLocalizableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryID { get; set; }
   
    [Required]
    [StringLength(500)]
    public string? CategoryName { get; set; }

    [Required]
    public string CategoryImage { get; set; }
    [Required]
    public int ParentID { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    [StringLength(500)]
    public string Slug { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }

    public List<CategoryTrans>? CategoryTrans { get; set; }

    public List<Part>? Parts { get; set; }

}
