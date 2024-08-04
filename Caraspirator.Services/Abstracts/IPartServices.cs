
namespace Caraspirator.Services.Abstracts;

public interface IPartServices
{
    Task<IEnumerable<Part>> GetPartsListAsync();
    Task<IEnumerable<Part>> GetPartsListByCategoryAndSubAsync(int cateid, int subid);
    Task<IEnumerable<Part>> GetPartsListByCarAsync(int carid);
    
    Task<Part> GetPartByIdAsync(int id);

    Task<string> EditPartAsync(Category category);



    Task<Part> GetPartByNameAsync(string name);

    Task<string> AddCategoryAsync(Category category);

    Task<bool> IsPartNameExistAsync(string name);

    Task<string> DeletePartAsync(Category category);

    IQueryable<Part> GetPartsQueryable();

    public IQueryable<Part> GetPartByCarIDQuerable(int CID);
}
