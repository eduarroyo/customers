using FluentValidation;

namespace Customers.Api.Customers.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 200).WithMessage("Name must be between 1 and 200 characters");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required")
            .Length(1, 200).WithMessage("Surname must be between 1 and 200 characters");
        RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required")
            .IsInEnum().WithMessage("Gender must be Male, Female or Other");
        RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Birth date is required.");
        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("Address allows just 500 characters.");
        RuleFor(x => x.Country)
            .MaximumLength(200).WithMessage("Address allows just 200 characters.");
        RuleFor(x => x.PostalCode)
            .MaximumLength(200).WithMessage("PostalCode allows just 20 characters.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is mandatory")
            .Length(1, 320).WithMessage("Surname must be between 1 and 320 characters")
            .EmailAddress().WithMessage("Email must be a valid email address");
    }
}
