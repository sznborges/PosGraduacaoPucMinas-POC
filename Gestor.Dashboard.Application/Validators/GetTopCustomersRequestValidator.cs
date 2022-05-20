using FluentValidation;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;

namespace Gestor.Dashboard.Application.Validators
{
    public class GetTopCustomersRequestValidator : BaseValidator<GetTopCustomersRequest>
    {
        public GetTopCustomersRequestValidator()
        {
            RuleFor(x => x.Limit)
                .GreaterThan(0);
        }
    }
}
