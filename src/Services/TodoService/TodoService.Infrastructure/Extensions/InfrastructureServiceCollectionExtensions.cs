using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoService.Domain.RepositoryAbstractions.Read;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Infrastructure.Data;
using TodoService.Infrastructure.Repositories.Read;
using TodoService.Infrastructure.Repositories.Write;

namespace TodoService.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var writeDatabaseConnectionString = configuration.GetConnectionString("WriteDatabase") ?? throw new ArgumentNullException();
        services.AddDbContext<TodoWriteContext>(options =>
        {
            options.UseNpgsql(writeDatabaseConnectionString);
            options.UseCamelCaseNamingConvention();
        });

        var readDatabaseConnectionString = configuration.GetConnectionString("ReadDatabase") ?? throw new ArgumentNullException();
        services.AddDbContext<TodoReadContext>(options =>
        {
            options.UseNpgsql(readDatabaseConnectionString);
            options.UseCamelCaseNamingConvention();
        });
    }

    public static void AddReadRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ITodoSummaryRepository, TodoSummaryRepository>()
            .AddScoped<ISpaceSummaryRepository, SpaceSummaryRepository>();
    }

    public static void AddWriteRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ITodoRepository, TodoRepository>()
            .AddScoped<ISpaceRepository, SpaceRepository>();
    }
}