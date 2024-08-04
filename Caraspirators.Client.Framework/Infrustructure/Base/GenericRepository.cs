
using Caraspirators.Client.Framework.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Caraspirators.Client.Framework.Infrustructure.Base;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly IHttpClientFactory _httpClientFactory;
    //private readonly string _endpoint;

    public GenericRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
       // _endpoint = endpoint;
    }

    protected async Task<(T data, bool succeeded, string message)> ReadContentAsync<T>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<T>>(jsonResponse);
            return (result.data, result.succeeded, string.Join(", ", result.message));
        }
        else
        {
            return (default, false, $"Error: {response.StatusCode}");
        }
    }

    public async Task<HttpResponseMessage> ExecuteRequestAsync(HttpMethod method, string endpoint, HttpContent content = null)
    {

        var httpClient = _httpClientFactory.CreateClient("queen-http-client");
        var request = new HttpRequestMessage(method, endpoint) { Content = content };
        var response = await httpClient.SendAsync(request);
        return response;
    }
    
    public async Task<(T data, bool succeeded, string message)> GetAllAsync<T>(string _endpoint)
    {
        var response = await ExecuteRequestAsync(HttpMethod.Get, _endpoint);
        return await ReadContentAsync<T>(response);
    }

 
    public async Task<(T data, bool succeeded, string message)> GetByIdAsync(string _endpoint,int id)
    {
        var response = await ExecuteRequestAsync(HttpMethod.Get, $"{_endpoint}/{id}");
        return await ReadContentAsync<T>(response);
    }

    protected async Task<(T1 data, bool succeeded, string message)> AddAsync<T1>(string _endpoint, T entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await ExecuteRequestAsync(HttpMethod.Post, _endpoint, content);
        return await ReadContentAsync<T1>(response);
    }

    public async Task<(T1 data, bool succeeded, string message)> CreateAsync<T1>(string endpoint, object entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await ExecuteRequestAsync(HttpMethod.Post, endpoint, content);
        return await ReadContentAsync<T1>(response);
    }



    public async Task UpdateAsync(string _endpoint,T entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await ExecuteRequestAsync(HttpMethod.Put, _endpoint, content);
    }

    public async Task DeleteAsync(string _endpoint,int id)
    {
        await ExecuteRequestAsync(HttpMethod.Delete, $"{_endpoint}/{id}");
    }

 
}