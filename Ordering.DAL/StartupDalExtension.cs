using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.DAL.Core;
using Ordering.DAL.Core.IConfiguration;
using Ordering.DAL.Core.Repository;
using Ordering.DAL.Data;
using Ordering.Domain.OrderModel;

namespace Ordering.DAL;

public static class StartupDalExtension
{
    // public  IConfiguration Configuration { get; set; }
    //
    // public StartupDalExtension(IConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }
    
    public static void AddDataAccessService(this IServiceCollection services, IConfiguration? configuration)
    {
        // services.AddCommonService(Configuration);
        // services.AddDbContext<OrderDbContext>(o => 
        //     o.UseNpgsql(Configuration.GetConnectionString("postgres_datasource")));
        var test = configuration.GetConnectionString("postgres_datasource");
        Console.WriteLine(test);
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("postgres_datasource")));
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}