using Dapper;
using Gestor.Dashboard.Application.Contracts;
using MediatR;
using System.Data;

namespace Gestor.Dashboard.Application.Requests.CreateCustomer
{
    public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly Func<Task<IDbConnection>> _openConnectionAsync;

        public CreateCustomerRequestHandler(Func<Task<IDbConnection>> openConnectionAsync)
        {
            _openConnectionAsync = openConnectionAsync;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = @$"insert into Customer (Id, Name, Email, DDD, Phone, CPF) Output Inserted.Id 
values
    (@Id, @Name, @Email, @Ddd, @Phone, @Cpf)";

                var parameters = new
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Email = request.Email,
                    Ddd = request.DDD,
                    Phone = request.Phone,
                    Cpf = request.CPF
                };

                var command = new CommandDefinition(sql, parameters);

                using (var connection = await _openConnectionAsync())
                {
                    var id = await connection.QueryFirstOrDefaultAsync<Guid>(command);

                    return new CreateCustomerResponse
                    {
                        Id = id
                    };
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
