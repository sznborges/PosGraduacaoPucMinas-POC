﻿using Dapper;
using Gestor.Dashboard.Application.Model;
using Gestor.Dashboard.Application.Requests.GetTicketsByCategory;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using Moq;
using Moq.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Dashboard.Tests.Application.Requests
{
    public class GetTicketsByCityRequestHandlerTest
    {
        private readonly GetTicketsByCityRequestHandler _handler;
        private readonly Mock<IDbConnection> _conMock;

        public GetTicketsByCityRequestHandlerTest()
        {
            _conMock = new Mock<IDbConnection>();
            
            _handler = new GetTicketsByCityRequestHandler(() =>
            {
                return Task.FromResult(_conMock.Object);
            });
        }

        [Fact]
        public async Task Handle_Ok()
        {
            // Arrange
            var itens = AutoBogus.AutoFaker.Generate<DashboardItem>(5);
            var request = new GetTicketsByCityRequest();
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
