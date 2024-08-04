

namespace Caraspirator.Infrustructure.Abstracts;

public interface IPartRepository: IGenericRepositoryAsync<Part>
{
    Task<IEnumerable<Part>> GetPartsListAsync();

    Task<IEnumerable<Part>> GetPartsListByCarAsync(int carid);

    Task<IEnumerable<CarPart>> GetPartsListByCarDetailsAsync(int carid);
    
   Task<IEnumerable<Part>> GetPartsListByCategoryAndSubAsync(int cateid,int subid);
    Task<Part> GetPartByNameAsync(string id);

}
