using Gestor.Dashboard.Api.Attributes;
using Gestor.Dashboard.Application.Contracts;
using Gestor.Dashboard.Application.Requests.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Gestor.Dashboard.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CreateCustomerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<CreateCustomerResponse> Post([FromBody] CreateCustomerRequest request)
        {
            return await _mediator.Send(request);
        }

        /// <summary>
        /// Search customers
        /// </summary>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SearchCustomerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [HttpGet("search")]
        public async Task<SearchCustomerResponse> SearchCustomers([FromQuery] SearchCustomerRequest request)
        {
            return await _mediator.Send(request);
        }


    }
}