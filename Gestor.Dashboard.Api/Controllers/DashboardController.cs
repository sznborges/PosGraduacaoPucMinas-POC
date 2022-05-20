using Gestor.Dashboard.Application.Contracts;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gestor.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("types")]
        public async Task<DashboardItensResponse> GetByType([FromQuery] GetTicketsByCategoryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("categories")]
        public async Task<DashboardItensResponse> GetByCategory([FromQuery] GetTicketsByCategoryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("cities")]
        public async Task<DashboardItensResponse> GetByCity([FromQuery] GetTicketsByCityRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("customers")]
        public async Task<DashboardItensResponse> GetTopCustomers([FromQuery] GetTopCustomersRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}