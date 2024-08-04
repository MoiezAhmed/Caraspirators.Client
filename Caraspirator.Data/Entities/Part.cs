
using Caraspirator.Data.Commons;
using Caraspirator.Data.Entities.DTO;
using System.Text.Json.Serialization;

namespace Caraspirator.Data.Entities;
public class Part : GeneralLocalizableEntity

{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PartID { get; set; }
    public int CategoryID { get; set; }
    public Category? Category  { get; set; }
    public int SubcategoryID { get; set; }
    public string? Manufacturer { get; set; }
    public string? PartNumber { get; set; }
    public string? PartUrl { get; set; }
    public bool IsActive { get; set; }
    public int AvailableQuantity { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public  ICollection<PartTrans>? PartTrans { get; set; }
    [JsonIgnore]
    public ICollection<CarPart> CarPart { get; set; }
    //public ICollection<CarPart> car_part { get; set; }
    // public ICollection<PostTag> PostTag { get; set; }

}
