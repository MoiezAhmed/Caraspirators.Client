using Caraspirator.Data.Entities.Identity;
using Caraspirator.Data.Results;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Services.Abstracts;

public interface IAuthenticationService
{
    public Task<JwtAuthResult> GetJWTToken(EspkUser user);
    public JwtSecurityToken ReadJWTToken(string accessToken);

    public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
    public Task<JwtAuthResult> GetRefreshToken(EspkUser user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
    public Task<string> ValidateToken(string AccessToken);
    public Task<string> ConfirmEmail(int? userId, string? code);
    public Task<string> SendResetPasswordCode(string Email);
    public Task<string> ConfirmResetPassword(string Code, string Email);
    public Task<string> ResetPassword(string Email, string Password);


}
