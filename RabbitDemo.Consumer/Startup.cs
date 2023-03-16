using Microsoft.EntityFrameworkCore;
using RabbitDemo.Common.Extensions;
using RabbitDemo.Consumer.Data;
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
        services.AddHostedService<OrderHostedService>();

    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
    }

}