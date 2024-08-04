


namespace TestQueenApp.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit();
            RegisterAppServices(builder.Services);
           
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void RegisterAppServices(IServiceCollection services)
        {

            services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
            {
#if ANDROID
			return new Platforms.Android.AndroidHttpMessageHandler();
#elif IOS
                return new Platforms.iOS.IosHttpMessageHandler();
#endif
                return null;
            });

            services.AddHttpClient(AppConstants.HttpClientName, httpClient =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                                ? "https://10.0.2.2:7093"
                                : "https://localhost:7093";

                httpClient.BaseAddress = new Uri(baseAddress);
            })
    .ConfigureHttpMessageHandlerBuilder(configBuilder =>
    {
        var platformHttpMessageHandler = configBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
        configBuilder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
    });

            //Register Cache Barrel
            Barrel.ApplicationId = AppConstants.ApplicationId;
            services.AddSingleton<IBarrel>(Barrel.Current);


            //Register API Service
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddSingleton<IAuthService, AuthService>();


            //Register View Models
            services.AddSingleton<HomePageViewModel>();
            //services.AddSingleton<CategoriespageViewModel>();
            //services.AddSingleton<ProfilePageViewModel>();
            //services.AddSingleton<ShoppingCartPageViewModel>();

            //Register View 
            services.AddSingleton<HomePage>();
            services.AddSingleton<SigninPage>();
            services.AddSingleton<MainPage>();


        }
    }

  
}
