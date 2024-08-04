
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caraspirator.Data.Shared.Entities;

public class Category
{
    public int categoryID { get; set; }
    public string? categoryName { get; set; }
    public string? categoryImage { get; set; }
    public int parentID { get; set; }
    public bool isActive { get; set; }
    public string? slug { get; set; }
    public DateTime createdate { get; set; }
    public DateTime updatedat { get; set; }
}
