using Dapper;
using Gestor.Dashboard.Application.Contracts;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using Moq;
using Moq.Dapper;
using System.Data;

namespace Gestor.Dashboard.Tests.Application.Requests
{
    public class GetTicketsByTypeRequestHandlerTest
    {
        private readonly GetTicketsByTypeRequestHandler _handler;
        private readonly Mock<IDbConnection> _conMock;

        public GetTicketsByTypeRequestHandlerTest()
        {
            _conMock = new Mock<IDbConnection>();
            
            _handler = new GetTicketsByTypeRequestHandler(() =>
            {
                return Task.FromResult(_conMock.Object);
            });
        }

        [Fact]
        public async Task Handle_Ok()
        {
            // Arrange
            var itens = AutoBogus.AutoFaker.Generate<DashboardItem>(5);
            var request = new GetTicketsByTypeRequest();
            _conMock.SetupDapperAsync(x => x.QueryAsync<DashboardItem>(It.IsAny<CommandDefinition>()))
                .ReturnsAsync(itens);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.Data.Any());
        }
    }
}
