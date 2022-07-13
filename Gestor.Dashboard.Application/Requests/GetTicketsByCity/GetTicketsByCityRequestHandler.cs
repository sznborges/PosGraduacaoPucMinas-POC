using Dapper;
using Gestor.Dashboard.Application.Contracts;
using Gestor.Dashboard.Application.Model;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using MediatR;
using System.Data;

namespace Gestor.Dashboard.Application.Requests.GetTicketsByCategory
{
    public class GetTicketsByCityRequestHandler : IRequestHandler<GetTicketsByCityRequest, DashboardItensResponse>
    {
        private readonly Func<Task<IDbConnection>> _openConnectionAsync;

        public GetTicketsByCityRequestHandler(Func<Task<IDbConnection>> openConnectionAsync)
        {
            _openConnectionAsync = openConnectionAsync;
        }

        public async Task<DashboardItensResponse> Handle(GetTicketsByCityRequest request, CancellationToken cancellationToken)
        {
            var sql = @$"SELECT TOP {request.Limit} City Label, count(1) Value 
FROM TicketReport 
WHERE FinishDate BETWEEN @startRangeDate and @endRangeDate
GROUP BY city
ORDER BY Value DESC";

            var parameters = new
            {
                startRangeDate = request.StartRangeDate,
                endRangeDate = request.EndRangeDate
            };

            var command = new CommandDefinition(sql, parameters);

            using (var connection = await _openConnectionAsync())
            {
                var results = await connection.QueryAsync<DashboardItem>(command);

                return new DashboardItensResponse
                {
                    Data = results.ToArray()
                };
            }
        }
    }
}
