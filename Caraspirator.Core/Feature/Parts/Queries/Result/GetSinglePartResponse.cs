using Caraspirator.Data.Entities.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Parts.Queries.Result;

public class GetSinglePartResponse
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PartID { get; set; }

    public string? PartName { get; set; }
    public int CategoryID { get; set; }
    public string? CategoryName { get; set; }
    public int SubcategoryID { get; set; }
    public string? SubCategoryName { get; set; }
    public string? Manufacturer { get; set; }
    public string? PartNumber { get; set; }
    public string? PartUrl { get; set; }
    public bool IsActive { get; set; }
    public int AvailableQuantity { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public GetSinglePartResponse(
          int _partid
        , string _partName
        , int categoryID
        , string _categoryName
        , int _subcategoryID
        , string _subCategoryName
        , string _manufacturer
        , string _partNumber
        , string _partUrl
        , bool _isActive
        , int _availableQuantity
        , DateTime _createdAt
        , DateTime _updatedAt)
    {
        PartID=_partid;
        PartName = _partName;
        CategoryID = categoryID;
        CategoryName = _categoryName;     
        SubcategoryID = _subcategoryID;
        SubCategoryName = _subCategoryName;
        Manufacturer  = _manufacturer;
        PartNumber = _partNumber;
        PartUrl = _partUrl;
        IsActive = _isActive;
        AvailableQuantity = _availableQuantity;
        CreatedAt = _createdAt;
        UpdatedAt = _updatedAt;

    }

}
