
using Caraspirator.Core.Feature.Categories.Commands.Models;
using Caraspirator.Core.Feature.Categories.Queries.Models;
using Caraspirator.Core.Feature.Categories.Queries.Result;
using Caraspirator.Data.AppMetaData;
using CarSpirators.API.Base;
using MediatR;
using System.Xml.Linq;

namespace CarSpirators.API.Controllers;
//[Route("Caraspirator/v1/[controller]")]
[ApiController]
public class CategoriesController : AppControllerBase
{
 //   private readonly ICategoryService<Category> categoryService;


    [HttpGet(Router.CategoriesRouter.List)]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var response = await _mediator.Send(new GetCategoryListQuery());

        return Ok(response);
    }

    [HttpGet(Router.CategoriesRouter.CategoryByName)]
    public async Task<IActionResult> GetCategoryByNameAsync([FromRoute] string name)
    {    
        return NewResult(await _mediator.Send(new GetCategoryByNameQuery(name)));
    }

    [HttpGet(Router.CategoriesRouter.GetByID)]
    public async Task<IActionResult> GetCategoryByID([FromRoute] int id)
    {
        return NewResult(await _mediator.Send(new GetCategoryByIdQuery(id)));
    }


    [HttpPost(Router.CategoriesRouter.Create)]
    public async Task<IActionResult> Create([FromBody] AddCategoryCommand command)
    {
        
        var response = await _mediator.Send(command);
       
        return NewResult(response);
     
    }

    [HttpPost(Router.CategoriesRouter.Edit)]
    public async Task<IActionResult> Edit([FromBody] EditCategoryCommand command)
    {

        var response = await _mediator.Send(command);

        return NewResult(response);

    }
 
    [HttpDelete(Router.CategoriesRouter.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        return NewResult(await _mediator.Send(new DeleteCategoryCommand(id)));

    }

    [HttpGet(Router.CategoriesRouter.Paginated)]
    public async Task<IActionResult> Paginated([FromQuery] GetCategoryPaginatedListQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPost(Router.CategoriesRouter.GetSubById)]
    public async Task<IActionResult> GetSubCategoriesAsync([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetSubCategoryListQuery(id));

        return Ok(response);
    }

    [HttpGet(Router.CategoriesRouter.SubPaginated)]
    public async Task<IActionResult> SubCategoriesPaginated([FromQuery] GetSubCategoryPaginatedListQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }

}
