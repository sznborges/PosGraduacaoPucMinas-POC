using Dapper;
using Gestor.Dashboard.Application.Contracts;
using Gestor.Dashboard.Application.Model;
using MediatR;
using System.Data;

namespace Gestor.Dashboard.Application.Requests.CreateCustomer
{
    public class SearchCustomerRequestHandler : IRequestHandler<SearchCustomerRequest, SearchCustomerResponse>
    {
        private readonly Func<Task<IDbConnection>> _openConnectionAsync;

        public SearchCustomerRequestHandler(Func<Task<IDbConnection>> openConnectionAsync)
        {
            _openConnectionAsync = openConnectionAsync;
        }

        public async Task<SearchCustomerResponse> Handle(SearchCustomerRequest request, CancellationToken cancellationToken)
        {
            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(@"
                SELECT * FROM CUSTOMER customer
                /**where**/");

            if (!string.IsNullOrEmpty(request.Name))
            {
                sqlBuilder.Where("customer.name like @name", new
                {
                    name = $"%{request.Name}%"
                });
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                sqlBuilder.Where("customer.email like @email", new
                {
                    email = $"%{request.Email}%"
                });
            }

            if (!string.IsNullOrEmpty(request.CPF))
            {
                sqlBuilder.Where("customer.cpf = @cpf", new
                {
                    cpf = request.CPF.Replace(".", "").Replace("-", "")
                });
            }

            using (var connection = await _openConnectionAsync())
            {
                var customers = await connection.QueryAsync<Customer>(template.RawSql, template.Parameters);

                return new SearchCustomerResponse
                {
                    Customers = customers.ToArray()
                };
            }
        }
    }
}
