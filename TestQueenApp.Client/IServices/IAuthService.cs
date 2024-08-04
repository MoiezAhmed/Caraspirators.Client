
namespace TestQueenApp.Client.IServices;

public interface IAuthService
{
    Task<(LoginData data, bool succeeded, string message)> SigninAsync(SiginRequest request);
    Task<bool> IsUserAuthenticated();
    void Logout();
}
