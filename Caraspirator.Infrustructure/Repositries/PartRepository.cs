



using Microsoft.EntityFrameworkCore;

namespace Caraspirator.Infrustructure.Repositries;

public class PartRepository : GenericRepositoryAsync<Part>, IPartRepository
{
    private readonly DbSet<Part> _Parts;
    private readonly DbSet<CarPart> _carParts;
    private readonly DbSet<Car> _car;
    private readonly DbSet<Department> _departmentRepository;
    public PartRepository(AppDbContext dbContext) : base(dbContext)
    {
        _Parts = dbContext.Set<Part>();
        _carParts= dbContext.Set<CarPart>();
        _car = dbContext.Set<Car>();
        _departmentRepository = dbContext.Set<Department>();
        
    }

    public Task<Part> GetPartByNameAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Part>> GetPartsListAsync()
    {//  return await _Parts.Include(x => x.parttrans.Where(x=>x.lang.langua_id.Equals(1))).ToListAsync();
     //  return await _Parts.Include(x => x.parttrans).Include(c => c.car_part).ToListAsync();
       // await _Parts.Include(x => x.parttrans).ToListAsync();
        return  await _Parts.Include(x => x.PartTrans).Include(cp=>cp.CarPart).ThenInclude(c=>c.Car).ToListAsync();
    }

    public async Task<IEnumerable<Part>> GetPartsListByCategoryAndSubAsync(int catid, int subid)
    {
        //return await _Parts.Where(p => p.Category.CategoryID == catid && p.Category.ParentID == subid).Include(x => x.PartTrans)
        //.ToListAsync();

        return await _Parts.Where(p => p.Category.CategoryID== catid && p.Category.ParentID== subid).Include(pt=>pt.PartTrans)
        .ToListAsync();
        ;
    }
    public async Task<IEnumerable<Part>> GetPartsListByCarAsync(int id)
    {
        //return await _Parts.Include(x => x.PartTrans).Where(p => p.CarPart.Any(cp => cp.CarID == id))
        //.ToListAsync();
        return await _Parts.Where(p => p.CarPart.Any(cp => cp.CarID == id)).Include(x => x.PartTrans)
        .ToListAsync();
        ;
    }

 
    public Task<Part> GetPartByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CarPart>> GetPartsListByCarDetailsAsync(int carid)
    {
        throw new NotImplementedException();
    }
}
