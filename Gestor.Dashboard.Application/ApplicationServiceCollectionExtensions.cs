using FluentValidation;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using Gestor.Dashboard.Application.Validators;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace Gestor.Dashboard.Application
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(GetTicketsByCategoryRequest));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddSqlServerConnection(configuration.GetConnectionString("SqlServer"));

            AssemblyScanner.FindValidatorsInAssembly(typeof(GetTicketsByCategoryRequest).Assembly)
              .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            return services;
        }

        public static IServiceCollection AddSqlServerConnection(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<Func<Task<IDbConnection>>>(_ => async () =>
            {
                var connection = new SqlConnection(connectionString);

                await connection.OpenAsync();

                return connection;
            });

            return services;
        }
    }
}