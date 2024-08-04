

namespace Caraspirators.Client.Framework.Infrustructure.Base;

public interface IGenericRepository<T> where T : class
{
    //Task<HttpResponseMessage> LoginAsync(SiginRequest request);
    Task<(T data, bool succeeded, string message)> GetAllAsync<T>(string _endpoint);
    Task<(T data, bool succeeded, string message)> GetByIdAsync(string _endpoint,int id);
    //Task<(T1 data, bool succeeded, string message)> CreateAsync<T1>(string _endpoint, T entity);
    Task<(T1 data, bool succeeded, string message)> CreateAsync<T1>(string endpoint, object entity);
    Task UpdateAsync(string _endpoint,T entity);
    Task DeleteAsync(string _endpoint, int id);
    Task<HttpResponseMessage> ExecuteRequestAsync(HttpMethod method, string endpoint, HttpContent content = null);
}
