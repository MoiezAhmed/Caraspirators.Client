using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Data.Entities;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StudID { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    [StringLength(500)]
    public string? Address { get; set; }
    [StringLength(500)]
    public string? Phone { get; set; }
    public int? DID { get; set; }

    [ForeignKey("DID")]
   
    public  Department? Department { get; set; }


}
