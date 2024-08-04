using Caraspirators.Client.Infrustructure.Abstracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Caraspirators.Client.Infrustructure.Repositries;

public class AuthRepository 
{
    private readonly HttpClient _httpClient;

    public AuthRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SiginResponse> LoginAsync(SiginRequest request)
    {
        var jsonRequest = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://yourapi.com/login", content);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SiginResponse>(jsonResponse);
        }

        return new SiginResponse { succeeded = false, message = "Login failed" };
    }


}