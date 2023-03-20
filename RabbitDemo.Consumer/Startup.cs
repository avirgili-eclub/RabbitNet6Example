using Microsoft.EntityFrameworkCore;
using Ordering.DAL;
using Ordering.DAL.Core.IConfiguration;
using Ordering.DAL.Data;
using RabbitDemo.Common.Extensions;
using RabbitDemo.Consumer.Services;
using RabbitDemo.Consumer.Services.RabbitMq;

namespace RabbitDemo.Consumer;

public class Startup
{
    public IConfiguration Configuration { get; set; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddCommonService(Configuration);
        // services.AddDbContext<OrderDbContext>(o => 
        //     o.UseNpgsql(Configuration.GetConnectionString("postgres_datasource")));
        // services.AddSingleton<IOrderDbContext, OrderDbContext>();
        // services.AddSingleton<IConsumerService, ConsumerService>();
        // services.AddHostedService<ConsumerHostedService>();
        services.AddMessaging();
        services.AddDataAccessService(Configuration);
        services.AddAuthorization();
        services.AddControllers();
        services.AddSingleton<MyScopedServiceFactory>();
        services.AddHostedService<OrderHostedService>();
        

        // services.AddDatabaseDeveloperPageExceptionFilter();

    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            //TODO: primero se debe agregar en el COnfigureServices la configuracion.
            // app.UseSwagger();
            // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitNet6Demo v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}