using MerchStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MerchStore.Api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider){
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MerchStoreContext>();
        dbContext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration){
        var connString = configuration.GetConnectionString("MerchStoreContext");
        services.AddSqlServer<MerchStoreContext>(connString)
            .AddScoped<IProductsRepository, EntityFrameworkProductRepository>();

        return services;

    }
    
}