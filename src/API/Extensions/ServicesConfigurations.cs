using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Domain.Profiles;
using Domain.Profiles.Interfaces;
using Domain.Services;
using Domain.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServicesConfigurations
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageProfile, ProductProfile>();
            services.AddScoped<IProductsService, ProductsService>();
        }

        public static void AddDataLayerRepository(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IProductsRepository, ProductRepository>();
        }
    }
}
