using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities;

public class CarPart
{
    [JsonIgnore]
    public int CarID { get; set; }
    [JsonIgnore]
    public Car? Car { get; set; }
    [JsonIgnore]
    public int PartID { get; set; }   
    public Part? Part { get; set; }
}
