namespace Caraspirators.Client.other;

public class CategoryService
{
    private readonly HttpClient _client;

    public CategoryService()
    {

        _client = new HttpClient
        {
            //BaseAddress = new Uri("https://moiez007-001-site1.gtempurl.com/Caraspirator/v1/"),
            Timeout = TimeSpan.FromMinutes(5) // Set a timeout value (e.g., 5 minutes)
        };

    }
    public async Task<T> GetAsync<T>(string endpoint)
    {
        var urllast = "https://moiez007-001-site1.gtempurl.com/Caraspirator/v1/" + endpoint;
        var response = await _client.GetAsync(urllast);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }
}
