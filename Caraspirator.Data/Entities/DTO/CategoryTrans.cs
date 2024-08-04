

using System.Text.Json.Serialization;

namespace Caraspirator.Data.Entities.DTO;

public class CategoryTrans
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategorytransID { get; set; }  
    public string? CategorytransName { get; set; }
    public string? CategorytransDescription { get; set; }
    //public espk_language? lang { get; set; }

    public int? CategoryID { get; set; }
 
    public Category? Category { get; set; }
    //[ForeignKey(nameof(espk_language))]
    


}
