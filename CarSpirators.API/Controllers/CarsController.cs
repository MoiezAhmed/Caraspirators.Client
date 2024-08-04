using Caraspirator.Core.Feature.Cars.Queries.Models;
using Caraspirator.Core.Feature.Categories.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSpirators.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CarsController : ControllerBase
    {
        private readonly ICarServices _carService;
        private readonly IMediator? _mediator;
        public CarsController(ICarServices carService, IMediator mediatorInstance)
        {
            _carService = carService;
            _mediator = mediatorInstance;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCarPartsAsync([FromQuery] GetCarPartByCarIdQuery query)
        {        //[FromQuery] GetSubCategoryPaginatedListQuery query    
            var response = await _mediator.Send(query);
         
            return Ok(response);
        }
    }
}
