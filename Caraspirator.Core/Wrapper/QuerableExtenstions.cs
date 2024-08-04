using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Core.Wrapper;

public static class QuerableExtenstions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source,int pageNumber,int pageSize)
    where T :class    {
        if(source == null) throw new ArgumentNullException("empty");

        pageNumber=pageNumber==0 ? 1 : pageNumber;
        pageSize=pageSize==0 ? 1 : pageSize;
        int count=await source.AsNoTracking().CountAsync();
        if(count == 0) { 
         return PaginatedResult<T>.Success(new List<T>(), count, pageNumber, pageSize);
        }
        pageNumber=pageNumber<=0 ? 1 : pageNumber;
        var item = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
             return PaginatedResult<T>.Success(item,count, pageNumber, pageSize);
          }

}
