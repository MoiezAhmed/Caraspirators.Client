
using Caraspirator.Core.Feature.Behaviors;
using Caraspirator.Core.Mapping.Cars;
using Microsoft.Extensions.DependencyInjection;
using Caraspirator.Core.Mapping.Categories;
using Caraspirator.Core.Mapping.Roles;
using Caraspirator.Core.Mapping.Users;
using FluentValidation;


namespace Caraspirator.Core
{
    public static class ModuleCoreDependancies
    {
        public static IServiceCollection AddCoreDependancies(this IServiceCollection services)
        {
            services.AddMediatR(cfh=>cfh.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //var automapper = new MapperConfiguration(item => item.AddProfile(new CategoryProfile()));
            //IMapper mapper = automapper.CreateMapper();
            //services.AddSingleton(mapper);

            //var automapper1 = new MapperConfiguration(item => item.AddProfile(new CarProfile()));
            //IMapper mapper1 = automapper1.CreateMapper();
            //services.AddSingleton(mapper1);

            //var automapper2 = new MapperConfiguration(item => item.AddProfile(new UserProfile()));
            //IMapper mapper2 = automapper2.CreateMapper();
            //services.AddSingleton(mapper2);

            //var automapper3 = new MapperConfiguration(item => item.AddProfile(new RoleProfile()));
            //IMapper mapper3 = automapper3.CreateMapper();
            //services.AddSingleton(mapper3);
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

          //  Configuration Of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
