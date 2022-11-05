using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.PermissionGroupVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.PermissionGroup
{
    public class CreatePermissionGroupInputValidator : AbstractValidator<CreatePermissionGroupInput>
    {
        public CreatePermissionGroupInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Name 50 karakterden fazla olamaz");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description alanı zorunludur.").MaximumLength(CoreConsts.MaxLength200).WithMessage("Description 200 karakterden fazla olamaz");
        }
    }
}
