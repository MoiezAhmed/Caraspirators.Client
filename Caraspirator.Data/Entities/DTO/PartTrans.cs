
using System.Text.Json.Serialization;

namespace Caraspirator.Data.Entities.DTO;
public class PartTrans
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ParttransID { get; set; }
    public string ParttransName { get; set; }
    public string ParttransDescription { get; set; }
    public int? PartID { get; set; }
    [JsonIgnore]
    public  Part? Part { get; set; }
  

}
