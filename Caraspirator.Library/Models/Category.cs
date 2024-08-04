

namespace Caraspirator.Library.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int category_id { get; set; }
    public string Category_Name { get; set; }

    public string category_image { get; set; }
    public int parent_id { get; set; }
    public bool is_active { get; set; }
    public string slug { get; set; }
    public DateTime created_at { get; set; }
   
    public DateTime updated_at { get; set; }
  
}
