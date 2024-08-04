using Caraspirators.Client.Framework.Infrustructure.Abstracts;
using System.Net;
namespace Caraspirators.Client.Framework.Infrustructure.Repositries;
public class AuthRepository : GenericRepository<LoginData>, IAuthRepository
{
  

    public AuthRepository(IHttpClientFactory httpClientFactory, IBarrel barrel)
        : base(httpClientFactory) 
    { 
       
    }

 
    public async Task<(LoginData data, bool succeeded, string message)> LoginAsync(string endpoint, SiginRequest loginRequest)
    {
        var (data, succeeded, message) = await CreateAsync<LoginData>(endpoint, loginRequest);
        return (data, succeeded, message);
    }
}