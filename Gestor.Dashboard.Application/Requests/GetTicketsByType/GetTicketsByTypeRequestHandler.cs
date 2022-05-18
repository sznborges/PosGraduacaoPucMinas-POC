using Dapper;
using Gestor.Dashboard.Application.Contracts;
using MediatR;
using System.Data;

namespace Gestor.Dashboard.Application.Requests.GetTicketsByType
{
    public class GetTicketsByTypeRequestHandler : IRequestHandler<GetTicketsByTypeRequest, DashboardItensResponse>
    {
        private readonly Func<Task<IDbConnection>> _openConnectionAsync;

        public GetTicketsByTypeRequestHandler(Func<Task<IDbConnection>> openConnectionAsync)
        {
            _openConnectionAsync = openConnectionAsync;
        }

        public async Task<DashboardItensResponse> Handle(GetTicketsByTypeRequest request, CancellationToken cancellationToken)
        {
            var sql = "SELECT Type Label, count(1) Value FROM TicketReport GROUP BY type";

            using (var connection = await _openConnectionAsync())
            {
                var results = await connection.QueryAsync<DashboardItem>(sql);

                return new DashboardItensResponse
                {
                    Data = results.ToArray()
                };
            }
        }
    }
}
