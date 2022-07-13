using FluentValidation;
using Gestor.Dashboard.Application.Requests.CreateCustomer;

namespace Gestor.Dashboard.Application.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(80);

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(80)
                .EmailAddress();

            RuleFor(x => x.DDD)
                .NotEmpty()
                .MaximumLength(2)
                .Must(x => IsNumber(x))
                .WithMessage("Invalid DDD");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Length(9)
                .Must(x => IsNumber(x))
                .WithMessage("Invalid Phone"); 

            RuleFor(x => x.CPF)
                .NotEmpty();

            RuleFor(x => x.CPF)
                .Must(x => CpfValidator.IsCpf(x))
                .WithMessage("Invalid Cpf");

        }

        private bool IsNumber(string value)
        {
            return int.TryParse(value, out _);
        }
    }
}
