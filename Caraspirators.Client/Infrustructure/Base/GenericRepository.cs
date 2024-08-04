
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Caraspirators.Client.Infrustructure.Base;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly string _endpoint;

    public GenericRepository(HttpClient httpClient, string endpoint)
    {
        _httpClient = httpClient;
        _endpoint = endpoint;
    }

    public async Task<HttpResponseMessage> GetAsync()
    {
        return await _httpClient.GetAsync(_endpoint);
    }

    public async Task<HttpResponseMessage> LoginAsync(SiginRequest request)
    {
        var jsonRequest = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        return await _httpClient.PostAsync($"{_endpoint}/login", content);
    }

    public async Task<HttpResponseMessage> GetAllAsync()
    {
        return await _httpClient.GetAsync(_endpoint);
    }

    public async Task<HttpResponseMessage> GetByIdAsync(int id)
    {
        return await _httpClient.GetAsync($"{_endpoint}/{id}");
    }

    public async Task<HttpResponseMessage> AddAsync(T entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await _httpClient.PostAsync(_endpoint, content);
    }

    public async Task<HttpResponseMessage> UpdateAsync(T entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return await _httpClient.PutAsync(_endpoint, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(int id)
    {
        return await _httpClient.DeleteAsync($"{_endpoint}/{id}");
    }

   
}
