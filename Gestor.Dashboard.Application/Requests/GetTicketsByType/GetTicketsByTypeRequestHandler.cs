using Dapper;
using Gestor.Dashboard.Application.Contracts;
using MediatR;
using System.Data;

namespace Gestor.Dashboard.Application.Requests.GetTicketsByType
{
    public class GetTicketsByTypeRequestHandler : IRequestHandler<GetTicketsByCategoryRequest, DashboardItensResponse>
    {
        private readonly Func<Task<IDbConnection>> _openConnectionAsync;

        public GetTicketsByTypeRequestHandler(Func<Task<IDbConnection>> openConnectionAsync)
        {
            _openConnectionAsync = openConnectionAsync;
        }

        public async Task<DashboardItensResponse> Handle(GetTicketsByCategoryRequest request, CancellationToken cancellationToken)
        {
            var sql = @$"SELECT TOP {request.Limit} Type Label, count(1) Value 
FROM TicketReport 
WHERE FinishDate BETWEEN @startRangeDate and @endRangeDate
GROUP BY type   
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
