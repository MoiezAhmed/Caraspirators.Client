
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caraspirators.Client.Models;

public class Category
{
    public int category_id { get; set; }
    public string Category_Name { get; set; }

    public string category_image { get; set; }
    public int parent_id { get; set; }
    public bool is_active { get; set; }
    public string slug { get; set; }
    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }
}
