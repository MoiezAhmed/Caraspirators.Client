using Caraspirator.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Caraspirator.Data.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Caraspirator.Infrustructure;

public static class ServiceRegisteration
{
    public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
    {

        //JWT Authentication
        var jwtSettings = new JwtSettings();
        configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
        services.AddSingleton(jwtSettings);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
   .AddJwtBearer(x =>
   {
       x.RequireHttpsMetadata = false;
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = jwtSettings.ValidateIssuer,
           ValidIssuers = new[] { jwtSettings.Issuer },
           ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
           ValidAudience = jwtSettings.Audience,
           ValidateAudience = jwtSettings.ValidateAudience,
           ValidateLifetime = jwtSettings.ValidateLifeTime,
       };
   });
        services.AddAuthorization(option =>
        {
            option.AddPolicy("CreateStudent", policy =>
            {
                policy.RequireClaim("Create Student", "True");
            });
            option.AddPolicy("DeleteStudent", policy =>
            {
                policy.RequireClaim("Delete Student", "True");
            });
            option.AddPolicy("EditStudent", policy =>
            {
                policy.RequireClaim("Edit Student", "True");
            });
        });

        return services;
    }
}
