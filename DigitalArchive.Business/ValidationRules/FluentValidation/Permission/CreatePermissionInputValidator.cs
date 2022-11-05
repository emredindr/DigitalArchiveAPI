using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.PermissionVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.Permission
{
    public class CreatePermissionInputValidator : AbstractValidator<CreatePermissionInput>
    {
        public CreatePermissionInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Name 50 karakterden fazla olamaz");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description alanı zorunludur.").MaximumLength(CoreConsts.MaxLength100).WithMessage("Description 100 karakterden fazla olamaz");

            RuleFor(x => x.PermissionGroupId).GreaterThanOrEqualTo(1);
        }
    }
}
