using Gestor.Dashboard.Application.Contracts;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Get data by Type.
        /// </summary>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DashboardItensResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("types")]
        public async Task<DashboardItensResponse> GetByType([FromQuery] GetTicketsByCategoryRequest request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Get data by Category.
        /// </summary>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DashboardItensResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("categories")]
        public async Task<DashboardItensResponse> GetByCategory([FromQuery] GetTicketsByCategoryRequest request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Get data by City.
        /// </summary>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DashboardItensResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("cities")]
        public async Task<DashboardItensResponse> GetByCity([FromQuery] GetTicketsByCityRequest request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Get data by Customer.
        /// </summary>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DashboardItensResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("customers")]
        public async Task<DashboardItensResponse> GetTopCustomers([FromQuery] GetTopCustomersRequest request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Get data by State.
        /// </summary>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DashboardItensResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("states")]
        public async Task<DashboardItensResponse> GetTopCustomers([FromQuery] GetTicketsByStateRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}