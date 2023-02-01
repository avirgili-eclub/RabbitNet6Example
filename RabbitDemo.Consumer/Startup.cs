using RabbitDemo.Common.Extensions;
using RabbitDemo.Consumer.Services;

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
        services.AddCommonService(Configuration);
        services.AddSingleton<IConsumerService, ConsumerService>();
        services.AddSingleton<IHelloWorldConsumerService, HelloWorldConsumerService>();
        services.AddHostedService<ConsumerHostedService>();
        services.AddHostedService<HelloWorldHostedService>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
    }
    
}