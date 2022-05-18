using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Gestor.Dashboard.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(GetTicketsByTypeRequest));
            services.AddSqlServerConnection(configuration.GetConnectionString("SqlServer"));

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