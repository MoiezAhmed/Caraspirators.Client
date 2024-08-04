using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Services.Implementation
{
    public class PartServices : IPartServices
    {
        private readonly IPartRepository _partRepository;
        public PartServices(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public Task<IEnumerable<Part>> GetPartsListAsync()
        {
            return _partRepository.GetPartsListAsync();
        }

        public Task<IEnumerable<Part>> GetPartsListByCarAsync(int carid)
        {
            return _partRepository.GetPartsListByCarAsync(carid);
        }

        public Task<IEnumerable<Part>> GetPartsListByCategoryAndSubAsync(int cateid, int subid)
        {
            return _partRepository.GetPartsListByCategoryAndSubAsync(cateid, subid);
        }
        public Task<string> AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeletePartAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditPartAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Part> GetPartByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Part> GetPartByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

       

        public IQueryable<Part> GetPartsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsPartNameExistAsync(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Part> GetPartByCarIDQuerable(int CID)
        {
            //   return _partRepository.GetTableNoTracking().Include(x=>x.CarPart).Where(x => x.CarPart.Equals(CID)).AsQueryable();
            return _partRepository.GetTableNoTracking().Where(p => p.CarPart.Any(cp => cp.CarID == CID)).AsQueryable();

      //      SELECT `p`.`PartID`, `p`.`AvailableQuantity`, `p`.`CategoryID`, `p`.`CreatedAt`, `p`.`IsActive`, `p`.`Manufacturer`, `p`.`PartNumber`, `p`.`PartUrl`, `p`.`SubcategoryID`, `p`.`UpdatedAt`
      //FROM `Parts` AS `p`
      //WHERE EXISTS(
      //    SELECT 1
      //    FROM `CarPart` AS `c`
      //    WHERE(`p`.`PartID` = `c`.`PartID`) AND(`c`.`CarID` = @__CID_0))
      //LIMIT @__p_2 OFFSET @__p_1


        }
    }
}
