
using Caraspirators.Client.Views;
using CommunityToolkit.Maui;
using UraniumUI;
using Constants = Caraspirators.Client.Models.Constants;

namespace Caraspirators.Client;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("RobotoSlab-Regular.ttf", "RobotoSlabRegular");
                fonts.AddFont("RobotoSlab-Medium.ttf", "RobotoSlabMedium");
                fonts.AddFont("RobotoSlab-Bold.ttf", "RobotoSlabBold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

       // //Register Services
        RegisterAppServices(builder.Services);

        return builder.Build();
    }

    private static void RegisterAppServices(IServiceCollection services)
    {
        services.AddHttpClient();

        //// Register Refit clients
        //services.AddRefitClient<ICategoryApi>()
        //        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.example.com"));

        //Add Platform specific Dependencies
        services.AddSingleton<IConnectivity>(Connectivity.Current);

        //Register Cache Barrel
        Barrel.ApplicationId = Constants.ApplicationId;
        services.AddSingleton<IBarrel>(Barrel.Current);


        //Register API Service
        // services.AddHttpClient<ICategoryRepository, CategoryService>();
         //  services.AddSingleton<ICategoryService, CategoriesService>();


        //Register View Models
        services.AddSingleton<HomePageViewModel>();
        services.AddSingleton<CategoriespageViewModel>();
        services.AddSingleton<ProfilePageViewModel>();
        services.AddSingleton<ShoppingCartPageViewModel>();

        //Register View 
        services.AddSingleton<CategoriesPage>();




    }

}
