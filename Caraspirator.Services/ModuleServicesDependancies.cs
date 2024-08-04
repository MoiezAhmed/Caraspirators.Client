
using Caraspirator.Infrustructure.Abstracts;
using Caraspirator.Infrustructure.Repositries;
using Caraspirator.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Caraspirator.Services;

public static class ModuleServicesDependancies
{
    public static IServiceCollection AddServicesDependancies(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericServices<>), typeof(GenericServices<>));
        services.AddTransient(typeof(ICategoryServices), typeof(CategoryServices));
        services.AddTransient(typeof(IPartServices), typeof(PartServices));
        services.AddTransient(typeof(ICarServices), typeof(CarServices)); 
        services.AddTransient(typeof(IAuthenticationService), typeof(AuthenticationService));
        services.AddTransient(typeof(IAuthorizationService), typeof(AuthorizationService));
        services.AddTransient<IEmailsService, EmailsService>();
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        return services;
    }
}
