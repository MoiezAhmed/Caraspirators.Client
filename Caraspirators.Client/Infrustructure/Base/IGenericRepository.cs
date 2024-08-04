using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.Infrustructure.Base;

public interface IGenericRepository<T> where T : class
{
    Task<HttpResponseMessage> LoginAsync(SiginRequest request);
    Task<HttpResponseMessage> GetAsync();
    Task<HttpResponseMessage> GetAllAsync();
    Task<HttpResponseMessage> GetByIdAsync(int id);
    Task<HttpResponseMessage> AddAsync(T entity);
    Task<HttpResponseMessage> UpdateAsync(T entity);
    Task<HttpResponseMessage> DeleteAsync(int id);
}
