
namespace Caraspirator.Data.Entities;

public class espk_language
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int langua_id { get; set; }

    [Required]
    public string? langua_name { get; set; }

    [Required]
    public string?langua_code { get; set; }

   
}
