using AddressBookAPI.DTOs;
using FluentValidation;

namespace AddressBookAPI.Validators
{
    public class AddressBookValidator : AbstractValidator<AddressBookDto>
    {
        public AddressBookValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Phone).Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits.");
        }
    }
}
