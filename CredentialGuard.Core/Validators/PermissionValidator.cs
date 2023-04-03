using CredentialGuard.Core.Entities;
using CredentialGuard.Core.Shared.Resources;
using FluentValidation;

namespace CredentialGuard.Core.Validators
{
    public class PermissionValidator : AbstractValidator<Permission>
    {
        public PermissionValidator()
        {
            RuleFor(p => p.Employee)
                .NotEmpty()
                .WithMessage(ErrorsMessage.EmptyEmployee);

            RuleFor(p => p.PermissionTypeId)
              .NotEmpty()
              .WithMessage(ErrorsMessage.EmptyPermissionType);

            RuleFor(p => p.PermissionDate)
              .NotEmpty()
              .WithMessage(ErrorsMessage.EmptyPermissionDate);
        }
    }
}
