using AutoMapper;
using Caraspirator.Core.Base;
using Caraspirator.Core.Feature.Cars.Queries.Models;
using Caraspirator.Core.Feature.Cars.Queries.Result;
using Caraspirator.Core.Feature.Parts.Queries.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Feature.Cars.Queries.Handlers;

public class CarHandler :ResponseHandler,
    IRequestHandler<GetCarPartByCarIdQuery, Response<GetSingleCarResponse>>
{
    private readonly ICarServices _carService;
    private readonly IPartServices _partService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public CarHandler(ICarServices carService, IPartServices partService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer):base(stringLocalizer)
    {
        this._carService = carService;
        this. _partService = partService;
        this._mapper = mapper;
        this._stringLocalizer = stringLocalizer;
    }
    public async Task<Response<GetSingleCarResponse>> Handle(GetCarPartByCarIdQuery request, CancellationToken cancellationToken)
    {

        var car = await _carService.GetCarPartListAsync(request.id);
        //check Is Not exist
        if (car == null) return NotFound<GetSingleCarResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
        var mapper = _mapper.Map<GetSingleCarResponse>(car);

        //pagination
        Expression<Func<Part, GetSinglePartResponse>> expression = e => new GetSinglePartResponse(
            e.PartID
         , ""
         , e.CategoryID
          , e.Category.CategoryName
         , e.CategoryID
         , ""
        , e.Manufacturer
        , e.PartNumber
        , e.PartUrl
        , e.IsActive
        , e.AvailableQuantity
        , e.CreatedAt.Value
        , e.UpdatedAt.Value);
        var PartsQuerable = _partService.GetPartByCarIDQuerable(request.id);
        var PaginatedList = await PartsQuerable.Select(expression).ToPaginatedListAsync(request.partPageNumber, request.partPageSize);
        mapper.Parts = PaginatedList;
        return Success(mapper);
    }

   
}
