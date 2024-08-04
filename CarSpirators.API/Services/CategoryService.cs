
namespace CarSpirators.API.Services;

public class CategoryService :ICategoryService<CategoryDTO>
{
    private readonly AppDbContext appDbContext;
    private readonly IMapper _mapper;
    public CategoryService(AppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        _mapper = mapper;

    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        
        var data= await appDbContext.Categories.ToListAsync();
        var response = _mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(data);
        return response;

    }
    
}
