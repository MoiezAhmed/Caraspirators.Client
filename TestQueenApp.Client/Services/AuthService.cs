using System.Text.Json;
using TestQueenApp.Client.IServices;

namespace TestQueenApp.Client.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {

        _authRepository = authRepository;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var serializedData = await SecureStorage.Default.GetAsync(AppConstants.AuthStorageKeyName);
        return !string.IsNullOrWhiteSpace(serializedData);
    }

    public void Logout() => SecureStorage.Default.Remove(AppConstants.AuthStorageKeyName);

    public async Task<(LoginData data, bool succeeded, string message)> SigninAsync(SiginRequest request)
    {
        var(data, succeeded,message)= await _authRepository.LoginAsync("/api/Authentication/Api/V1/Authentication/SignIn", request);

        if (succeeded)
        {
            try
            {
                // Check if data already exists in SecureStorage
                var existingData = await SecureStorage.Default.GetAsync(AppConstants.AuthStorageKeyName);
                if (string.IsNullOrEmpty(existingData))
                {
                    var serializedData = JsonSerializer.Serialize(data);
                    await SecureStorage.Default.SetAsync(AppConstants.AuthStorageKeyName, serializedData);
                }
                else
                {
                    // Handle existing data scenario if needed (e.g., overwrite or merge)
                    var serializedData = JsonSerializer.Serialize(data);
                    await SecureStorage.Default.SetAsync(AppConstants.AuthStorageKeyName, serializedData);
                }
            }
            catch (Exception ex)
            {
                // Log or handle storage exceptions
                return (data, false, $"Failed to store data securely: {ex.Message}");
            }
        }
        else
        {
            // Log or handle failed sign-in attempt
        }

        return (data, succeeded, message);
    }
}
