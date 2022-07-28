using Gestor.Dashboard.Application.Model;

namespace Gestor.Dashboard.Application.Contracts
{
    public class SearchCustomerResponse
    {
        /// <summary>
        /// The customers
        /// </summary>
        public Customer[] Customers { get; set; }

        public SearchCustomerResponse()
        {
            Customers = Array.Empty<Customer>();
        }
    }
}
