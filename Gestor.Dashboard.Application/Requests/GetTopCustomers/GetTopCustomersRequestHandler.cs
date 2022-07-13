using Dapper;
using Gestor.Dashboard.Application.Contracts;
using Gestor.Dashboard.Application.Model;
using MediatR;
using System.Data;

namespace Gestor.Dashboard.Application.Requests.GetTicketsByType
{
    public class GetTopCustomersRequestHandler : IRequestHandler<GetTopCustomersRequest, DashboardItensResponse>
    {
        private readonly Func<Task<IDbConnection>> _openConnectionAsync;

        public GetTopCustomersRequestHandler(Func<Task<IDbConnection>> openConnectionAsync)
        {
            _openConnectionAsync = openConnectionAsync;
        }

        public async Task<DashboardItensResponse> Handle(GetTopCustomersRequest request, CancellationToken cancellationToken)
        {
            var sql = @$"SELECT TOP {request.Limit} CONCAT(CustomerName, ' - ', CustomerId) Label, count(1) Value
FROM TicketReport
WHERE FinishDate BETWEEN @startRangeDate and @endRangeDate
GROUP BY CustomerName, CustomerId
ORDER BY Value DESC";

            var parameters = new
            {
                limit = request.Limit,
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
