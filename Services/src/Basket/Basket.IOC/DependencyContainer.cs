using Basket.DataAccess;
using Basket.Domain.IGenericRepository;
using Basket.DataAccess.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Basket.ApplicationService.Services.Contract;
using Basket.ApplicationService.Services.Implementation;

namespace Basket.IOC
{
    public class DependencyContainer
    {
        public DependencyContainer()
        {
        }

        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            #region Configure Sql

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BasketDBConnection")));

            #endregion

            #region Rejester Repository

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region Rejester Servises

            services.AddScoped<IBasketService, BasketService>();

            #endregion

            #region Rejester AutoMapper

            //services.AddAutoMapper(typeof(MappingProfile));

            #endregion

            #region Rejester Librery

            //services.AddMediatR(typeof(MappingProfile).GetTypeInfo().Assembly);
            //services.AddValidatorsFromAssembly(assembly: typeof(CreateNewsCommandValidator).Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            #endregion
        }
    }
}