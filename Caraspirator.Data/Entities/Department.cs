using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DID { get; set; }
    //[StringLength(500)]
    public string? DNameAr { get; set; }
    [StringLength(200)]
    public string? DNameEn { get; set; }
    [JsonIgnore]
    public  ICollection<Student>? Students { get; set; }
}
