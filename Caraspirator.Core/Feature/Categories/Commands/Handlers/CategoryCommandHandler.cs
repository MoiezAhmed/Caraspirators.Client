using Caraspirator.Core.Base;
using Caraspirator.Core.Feature.Categories.Commands.Models;
using Caraspirator.Core.Feature.Categories.Queries.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Categories.Commands.Handlers;

public class CategoryCommandHandler :ResponseHandler, 
    IRequestHandler<AddCategoryCommand, Response<string>>,
    IRequestHandler<EditCategoryCommand, Response<string>>,
    IRequestHandler<DeleteCategoryCommand, Response<string>>
{

    private readonly ICategoryServices _categoryService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public CategoryCommandHandler(ICategoryServices categoryService
                                , IMapper mapper,
                                  IStringLocalizer<SharedResources> stringLocalizer) :base(stringLocalizer)
{
    this._categoryService = categoryService;
    this._mapper = mapper;
    this._stringLocalizer= stringLocalizer; 
}
public async Task<Response<List<GetCategoryListResponse>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
{
    var _Response = await _categoryService.GetCategoriesListAsync();
    var CategoriesMapper = _mapper.Map<IEnumerable<Category>, List<GetCategoryListResponse>>(_Response);
    return Success(CategoriesMapper);
}

    public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var CategoryMapper = _mapper.Map<Category>(request);
        var _Response = await _categoryService.AddCategoryAsync(CategoryMapper);
         if(_Response == "Success")
        {
            return Created("Add Successfully");
        }
        else {
            return BadRequest<string>(); 
        }
    }

    public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var _category = await _categoryService.GetCategoryByIdAsync(request.id);
        if (_category == null)
        {
            return NotFound<string>("Categry Not Found");
        }
       
        var _Response = await _categoryService.DeleteCategoryAsync(_category);
        if (_Response == "Success")
        {
            return Deleted<string>("Deleted Successfully");
        }
        else
        {
            return BadRequest<string>();
        }
    }
    public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
      
        var _category = await _categoryService.GetCategoryByIdAsync(request.id);
        if (_category == null)
        {
            return NotFound<string>("Categry Not Found");
        }
        var CategoryMapper = _mapper.Map(request, _category);
        var _Response = await _categoryService.EditCategoryAsync(CategoryMapper);
        if (_Response == "Success")
        {
            return Success((string)_stringLocalizer[SharedResourcesKeys.Updated]);
        }
        else
        {
            return BadRequest<string>();
        }
    }

  
}
