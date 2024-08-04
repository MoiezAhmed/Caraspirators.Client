

namespace Caraspirators.Client.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public Task<SiginResponse> SigninAsync(SiginRequest request)
    {
        //   return _authRepository.LoginAsync(request);
        return null;
    }
}