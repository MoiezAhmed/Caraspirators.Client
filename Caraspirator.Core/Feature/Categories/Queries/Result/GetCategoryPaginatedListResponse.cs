using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Categories.Queries.Result;

public class GetCategoryPaginatedListResponse
{
    [Key]
    public int CategoryID { get; set; }
    public string? CategoryName { get; set; }
    public string? CategoryImage { get; set; }
    public int ParentID { get; set; }
  
    public bool? IsActive { get; set; }

    public string? Slug { get; set; }

    public DateTime createdate { get; set; }

    public DateTime updatedat { get; set; }
    //public GetCategoryPaginatedListResponse(int _categoryid,string _CategoryName, string _categoryimage, int _parentid, bool _isactive, string _slug)
    //{
    //    CategoryID = _categoryid;
    //    CategoryName = _CategoryName;
    //    CategoryImage = _categoryimage;
    //    ParentID = _parentid;
    //    IsActive = _isactive;
    //    Slug = _slug;
    //}
}
