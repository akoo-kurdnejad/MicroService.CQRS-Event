using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.DataAccess;
using Order.Domain.IGenericRepository;
using Order.DataAccess.GenericRepository;

namespace Order.IOC
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
                options.UseSqlServer(configuration.GetConnectionString("OrderDBConnection")));

            #endregion

            #region Rejester Repository

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region Rejester Servises

            //services.AddScoped<INewsService, NewsService>();

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