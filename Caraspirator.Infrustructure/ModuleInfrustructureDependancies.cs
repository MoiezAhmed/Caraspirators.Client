
using Caraspirator.Data.Entities.Identity;
using Caraspirator.Infrustructure.Infrustructure;

namespace Caraspirator.Infrustructure;

public static class ModuleInfrustructureDependancies
{
    public static IServiceCollection AddInfrustructureDependancies(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
        services.AddTransient(typeof(IPartRepository), typeof(PartRepository));
        services.AddTransient(typeof(ICarRepository), typeof(CarRepository));
        services.AddTransient(typeof(IRefreshTokenRepository), typeof(RefreshTokenRepository));
        return services;
    }
}
