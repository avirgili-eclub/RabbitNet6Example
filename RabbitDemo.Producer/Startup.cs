

using RabbitDemo.Common.Extensions;
using RabbitDemo.Producer.Services;

namespace RabbitDemo.Producer;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddMessaging();
        services.AddSingleton<IOrderService, OrderService>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        
        app.UseCors(builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
        );
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

    }
}