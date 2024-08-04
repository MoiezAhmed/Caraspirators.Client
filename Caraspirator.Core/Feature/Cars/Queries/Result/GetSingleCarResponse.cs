

using Caraspirator.Core.Feature.Parts.Queries.Result;

namespace Caraspirator.Core.Feature.Cars.Queries.Result;

public class GetSingleCarResponse
{
    public int CarID { get; set; }
    public string? CarMake { get; set; }
    public string? CarModel { get; set; }
    public int CarYear { get; set; }
    public string? EngineType { get; set; }
    public string? VIN { get; set; }
    public PaginatedResult<GetSinglePartResponse>? Parts { get; set; }
}
