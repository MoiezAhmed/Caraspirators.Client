using Caraspirator.Services;
using Caraspirator.Infrustructure;
using Caraspirator.Core;
using Caraspirator.Core.Middleware;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;
using Caraspirator.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Caraspirator.Data.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using Caraspirator.Infrustructure.Seeder;
using Caraspirator.Data.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Database connection string 'DbConnection' is not found"));
});

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("ar-EG");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion
//var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
//IMapper mapper = automapper.CreateMapper();
//builder.Services.AddSingleton(mapper);
//builder.Services.AddScoped<ICategoryService<Category>, CategoryService>();

builder.Services.AddInfrustructureDependancies().AddServicesDependancies().AddCoreDependancies() ;
builder.Services.AddIdentity<EspkUser, Role>(option => {
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = true;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequireUppercase = true;
    option.Password.RequiredLength = 6;
    option.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    option.Lockout.MaxFailedAccessAttempts = 100;
    option.Lockout.AllowedForNewUsers = true;

    // User settings.
    option.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    option.User.RequireUniqueEmail = false;
    option.SignIn.RequireConfirmedEmail = true;
})
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
var jwtSettings = new JwtSettings();
var emailSettings = new EmailSettings();
builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
builder.Configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddSingleton(emailSettings);
builder.Services.AddAuthentication(x =>
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

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("UpdateUserClaims", policy =>
    {
        policy.RequireClaim("Update Claims", "True");
    });
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

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddTransient<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});

#region AllowCORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

#endregion

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<EspkUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseCors(CORS);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
