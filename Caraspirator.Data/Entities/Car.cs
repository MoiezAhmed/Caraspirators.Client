
using System.Text.Json.Serialization;

namespace Caraspirator.Data.Entities;

public class Car
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarID { get; set; }
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public int CarYear { get; set; }
    public string EngineType { get; set; }
    public string VIN { get; set; }
   
    public ICollection<CarPart> CarPart { get; set; }


}
