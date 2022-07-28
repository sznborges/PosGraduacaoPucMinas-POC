using Gestor.Dashboard.Application.Contracts;
using MediatR;

namespace Gestor.Dashboard.Application.Requests.CreateCustomer
{
    public class SearchCustomerRequest : IRequest<SearchCustomerResponse>
    {
        /// <summary>
        /// Customer's Name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Customer's E-mail
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Customer's CPF
        /// </summary>
        public string? CPF { get; set; }
    }
}
