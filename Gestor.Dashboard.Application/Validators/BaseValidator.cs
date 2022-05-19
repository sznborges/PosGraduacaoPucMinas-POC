using FluentValidation;
using Gestor.Dashboard.Application.Requests;

namespace Gestor.Dashboard.Application.Validators
{
    public class BaseValidator<T> : AbstractValidator<T> where T : DashboardRequestBase
    {
        public BaseValidator()
        {
            RuleFor(x => x.StartRangeDate)
                .Must(ValidDate)
                .WithMessage("'StartRangeDate' is required");

            RuleFor(x => x.EndRangeDate)
                .Must(ValidDate)
                .WithMessage("'EndRangeDate' is required");
        }

        private bool ValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
