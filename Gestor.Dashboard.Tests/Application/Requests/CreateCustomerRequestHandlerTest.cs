using Dapper;
using Gestor.Dashboard.Application.Model;
using Gestor.Dashboard.Application.Requests.CreateCustomer;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using Moq;
using Moq.Dapper;
using System.Data;

namespace Gestor.Dashboard.Tests.Application.Requests
{
    public class CreateCustomerRequestHandlerTest
    {
        private readonly CreateCustomerRequestHandler _handler;
        private readonly Mock<IDbConnection> _conMock;

        public CreateCustomerRequestHandlerTest()
        {
            _conMock = new Mock<IDbConnection>();
            
            _handler = new CreateCustomerRequestHandler(() =>
            {
                return Task.FromResult(_conMock.Object);
            });
        }

        [Fact]
        public async Task Handle_Ok()
        {
            // Arrange
            var customerId = new Guid();
            var request = AutoBogus.AutoFaker.Generate<CreateCustomerRequest>();
            _conMock.SetupDapperAsync(x => x.QueryFirstOrDefaultAsync<Guid>(It.IsAny<CommandDefinition>()))
                .ReturnsAsync(customerId);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.Id);
        }
    }
}
