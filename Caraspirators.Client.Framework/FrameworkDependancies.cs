using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caraspirators.Client.Framework;

public static class FrameworkDependancies
{

    public static IServiceCollection AddServicesDependancies(this IServiceCollection services)
    {
        //services.AddTransient(typeof(IGenericServices<>), typeof(GenericServices<>));
        //services.AddTransient(typeof(ICategoryServices), typeof(CategoryServices));
      // Add HttpClientFactory
        //services.AddHttpClient();

        //// Register Refit clients
        //services.AddRefitClient<ICategoryApi>()
        //        .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://yourapi.com"));

        //// Register services
        //services.AddTransient<ICategoryService, CategoryService>();

        //// Register Barrel caching
        //services.AddSingleton<IBarrel>(Barrel.Current);

        //// Register repositories
        //services.AddTransient<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
