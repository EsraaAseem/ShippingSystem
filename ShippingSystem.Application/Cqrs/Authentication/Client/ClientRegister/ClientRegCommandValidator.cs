

using FluentValidation;

namespace ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister
{
    internal class ClientRegCommandValidator : AbstractValidator<ClientRegCommand>
    {
        public ClientRegCommandValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage(" Email Reqguired");
            RuleFor(x => x.userName).NotEmpty().WithMessage("User Name is required");
            RuleFor(x => x.password).NotEmpty().WithMessage(" password is required");

        }
    }
}
