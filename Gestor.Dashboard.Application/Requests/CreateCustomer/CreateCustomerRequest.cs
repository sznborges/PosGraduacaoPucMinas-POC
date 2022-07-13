using Gestor.Dashboard.Application.Contracts;
using MediatR;

namespace Gestor.Dashboard.Application.Requests.CreateCustomer
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        /// <summary>
        /// Customer's Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Customer's E-mail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Customer's DDD
        /// </summary>
        public string DDD { get; set; }
        /// <summary>
        /// Customer's Phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Customer's CPF
        /// </summary>
        public string CPF { get; set; }
    }
}
