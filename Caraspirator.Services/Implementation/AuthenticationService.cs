﻿using Caraspirator.Data.Entities.Identity;
using Caraspirator.Data.Helper;
using Caraspirator.Data.Helpers;
using Caraspirator.Data.Results;
using Caraspirator.Infrustructure.Data;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirator.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly JwtSettings _jwtSettings;
    private readonly ConcurrentDictionary<string,RefreshToken> _UserRefreshToken;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly UserManager<EspkUser> _userManager;
    private readonly IEmailsService _emailsService;
    private readonly AppDbContext _applicationDBContext;
   // private readonly IEncryptionProvider _encryptionProvider;
    public AuthenticationService(
                                 JwtSettings jwtSettings,
                                 IRefreshTokenRepository refreshTokenRepository,
                                 UserManager<EspkUser> userManager,
                                  IEmailsService emailsService,
                                 AppDbContext applicationDBContext
                                )
    {
         _jwtSettings = jwtSettings;
        _refreshTokenRepository = refreshTokenRepository;
        _userManager = userManager;
        _UserRefreshToken =new ConcurrentDictionary<string,RefreshToken>();
        _applicationDBContext= applicationDBContext;
    //    _encryptionProvider = encryptionProvider;
        _emailsService=emailsService;
    }
    public async Task<JwtAuthResult> GetJWTToken(EspkUser user)
    {
        var (jwtToken, accessToken) = await GenerateJWTToken(user); 
        var  refreshtoken =  GetRefreshToken(user);
        var userRefreshToken = new UserRefreshToken
        {
            AddedTime = DateTime.Now,
            ExpiryDate = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpireDate),
            IsUsed = true,
            IsRevoked = false,
            JwtId = jwtToken.Id,
            RefreshToken = refreshtoken.TokenString,
            Token = accessToken,
            UserId = user.Id
        };
        
        await _refreshTokenRepository.AddAsync(userRefreshToken);
      
        var Response = new JwtAuthResult();
        Response.AccessToken = accessToken;
        Response.refreshToken = refreshtoken;
        return Response;
    }

    private async Task<(JwtSecurityToken, string)> GenerateJWTToken(EspkUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = await GetClaims(user);
        var jwtToken = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpireDate),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
    }
    public  RefreshToken GetRefreshToken(EspkUser user)
    {
        var refreshtoken = new RefreshToken
        {
            ExpireAt = DateTime.Now,
            UserName = user.UserName,
            TokenString = GenerateRefreshToken()
        };
        _UserRefreshToken.AddOrUpdate(refreshtoken.TokenString, refreshtoken, (s, t) => refreshtoken);
        return refreshtoken;    
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        var randomNumberGenerate = RandomNumberGenerator.Create();
        randomNumberGenerate.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task <List<Claim>> GetClaims(EspkUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
                new Claim(nameof(UserClaimModel.Id), user.Id.ToString())
            };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));

        }
        var userClaims = await _userManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);
        return claims;
    }

    public async Task<JwtAuthResult> GetRefreshToken(EspkUser user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
    {
       
        var (jwtSecurityToken, newToken) = await GenerateJWTToken(user);
        var Response = new JwtAuthResult();
        Response.AccessToken = newToken;
        var refreshTokenResult = new RefreshToken();
        refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
        refreshTokenResult.TokenString = refreshToken;
        refreshTokenResult.ExpireAt = (DateTime)expiryDate;
        Response.refreshToken = refreshTokenResult;
        return Response;
        
    }

    public JwtSecurityToken ReadJWTToken(string accessToken)
    {
        if (string.IsNullOrEmpty(accessToken))
        {
            throw new ArgumentNullException(nameof(accessToken));
        }
        var handler = new JwtSecurityTokenHandler();
        var response = handler.ReadJwtToken(accessToken);
        return response;
    }

    public async Task<string> ValidateToken(string accessToken)
    {

        var handler = new JwtSecurityTokenHandler();
        var parameters = new TokenValidationParameters
        {
            ValidateIssuer = _jwtSettings.ValidateIssuer,
            ValidIssuers = new[] { _jwtSettings.Issuer },
            ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
            ValidAudience = _jwtSettings.Audience,
            ValidateAudience = _jwtSettings.ValidateAudience,
            ValidateLifetime = _jwtSettings.ValidateLifeTime,
        };
        try
        {
            var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

            if (validator == null)
            {
                return "InvalidToken";
            }

            return "NotExpired";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken,string accesstoken,string refreshToken)
    {

        if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
        {
            return ("AlgorithmIsWrong", null);
        }
        if (jwtToken.ValidTo > DateTime.UtcNow)
        {
            return ("TokenIsNotExpired", null);
        }
        //get user
        var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;

        var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Token == accesstoken && x.RefreshToken == refreshToken && x.UserId == int.Parse(userId));
        if (userRefreshToken == null)
        {
            return ("RefreshTokenIsNotFound", null);
        }
        //validationtoken,get refresh token 
        if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
        {
            userRefreshToken.IsRevoked = true;
            userRefreshToken.IsUsed = false;
            await _refreshTokenRepository.UpdateAsync(userRefreshToken);
            return ("RefreshTokenIsExpired", null);
        }

        var expirydate = userRefreshToken.ExpiryDate;
        return (userId, expirydate);
    }

    public async Task<string> ConfirmEmail(int? userId, string? code)
    {
        if (userId == null || code == null)
            return "ErrorWhenConfirmEmail";
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);
        if (!confirmEmail.Succeeded)
            return "ErrorWhenConfirmEmail";
        return "Success";
    }

    public async Task<string> SendResetPasswordCode(string Email)
    {
        var trans = await _applicationDBContext.Database.BeginTransactionAsync();
        try
        {
            //user
            var user = await _userManager.FindByEmailAsync(Email);
            //user not Exist => not found
            if (user == null)
                return "UserNotFound";
            //Generate Random Number

            //Random generator = new Random();
            //string randomNumber = generator.Next(0, 1000000).ToString("D6");
            var chars = "0123456789";
            var random = new Random();
            var randomNumber = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            //update User In Database Code
            user.Code = randomNumber;
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return "ErrorInUpdateUser";
            var message = "Code To Reset Passsword : " + user.Code;
            //Send Code To  Email 
            await _emailsService.SendEmail(user.Email, message, "Reset Password");
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            return "Failed";
        }
    }

    public async Task<string> ConfirmResetPassword(string Code, string Email)
    {
        //Get User
        //user
        var user = await _userManager.FindByEmailAsync(Email);
        //user not Exist => not found
        if (user == null)
            return "UserNotFound";
        //Decrept Code From Database User Code
        var userCode = user.Code;
        //Equal With Code
        if (userCode == Code) return "Success";
        return "Failed";
    }

    public async Task<string> ResetPassword(string Email, string Password)
    {
        var trans = await _applicationDBContext.Database.BeginTransactionAsync();
        try
        {
            //Get User
            var user = await _userManager.FindByEmailAsync(Email);
            //user not Exist => not found
            if (user == null)
                return "UserNotFound";
            await _userManager.RemovePasswordAsync(user);
            if (!await _userManager.HasPasswordAsync(user))
            {
                await _userManager.AddPasswordAsync(user, Password);
            }
            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            return "Failed";
        }
    }
}
