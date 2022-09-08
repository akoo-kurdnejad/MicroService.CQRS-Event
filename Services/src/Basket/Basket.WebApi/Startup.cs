using Basket.IOC;
using MassTransit;

namespace Basket.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, conf) =>
                {
                    conf.Host(Configuration.GetValue<string>("EventBusSettings:HostAddress");
                });
            });

            services.AddMassTransitHostedService();

            DependencyContainer.ConfigureServices(Configuration,services);
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.Run();
        }
    }
}

