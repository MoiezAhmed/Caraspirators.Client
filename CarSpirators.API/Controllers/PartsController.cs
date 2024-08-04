

using Caraspirator.Core.Feature.Categories.Queries.Models;

namespace CarSpirators.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartsController : ControllerBase
{
    private readonly IPartServices _partService;
    public PartsController(IPartServices partService)
    {
        _partService = partService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPartsAsync()
    {
        var response = await _partService.GetPartsListAsync();

        return Ok(response);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetPartsByCarAsync(int id)
    {
        var response = await _partService.GetPartsListByCarAsync(id);

        return Ok(response);
    }

    [HttpGet("cateid")]
    public async Task<IActionResult> GetPartsListByCategoryAndSubAsync(int cateid,int subid)
    {
        var response = await _partService.GetPartsListByCategoryAndSubAsync(cateid, subid);

        return Ok(response);
    }
    
}
