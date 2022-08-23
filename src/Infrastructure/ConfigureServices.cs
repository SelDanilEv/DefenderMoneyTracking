using System.Net.Http.Headers;
using System.Reflection;
using Defender.MoneyTracking.Application.Common.Interfaces;
using Defender.MoneyTracking.Application.Common.Interfaces.Repositories;
using Defender.MoneyTracking.Application.Configuration.Options;
using Defender.MoneyTracking.Infrastructure.Clients;
using Defender.MoneyTracking.Infrastructure.Clients.Interfaces;
using Defender.MoneyTracking.Infrastructure.Clients.UserManagement;
using Defender.MoneyTracking.Infrastructure.Repositories.Sample;
using Defender.MoneyTracking.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Defender.MoneyTracking.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.RegisterServices();

        services.RegisterRepositories();

        services.RegisterApiClients();

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IAccountManagementService, AccountManagementService>();
        services.AddTransient<ISampleService, SampleService>();

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<ISampleRepository, SampleRepository>();

        return services;
    }

    private static IServiceCollection RegisterApiClients(
        this IServiceCollection services)
    {
        services.AddHttpClient<ISampleClient, SampleClient>("SampleClient",
            (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(
                serviceProvider.GetRequiredService<IOptions<SampleOption>>().Value.Url);
        });

        services.AddHttpClient<IUserManagementClient, UserManagementClient>("UserManagementClient",
            (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(
                serviceProvider.GetRequiredService<IOptions<UserManagementOption>>().Value.Url);

            var token = serviceProvider.GetRequiredService<ICurrentUserService>().Token;

            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(token);
            }
        });

        return services;
    }

}
