

namespace Caraspirator.Data.Entities;

public class PartVendor
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public int part_id { get; set; }
    public string vendor_id { get; set; }
    public string vendor_name { get; set; }
    public int vendor_price { get; set; }
    public string create_at { get; set;}

}
