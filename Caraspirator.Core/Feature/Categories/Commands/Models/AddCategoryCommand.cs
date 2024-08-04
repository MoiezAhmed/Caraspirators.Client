

namespace Caraspirator.Core.Feature.Categories.Commands.Models;

public class AddCategoryCommand:IRequest<Response<string>>
{
    public string? category_name { get; set; }
 
    public string? categoryimage { get; set; }
    
    public int parentid { get; set; }
   
    public bool isactive { get; set; }
  
    public string? slug { get; set; }
    public DateTime createdat { get; set; }

    public DateTime updatedat { get; set; }
 
    public string? status { get; set; }
}
