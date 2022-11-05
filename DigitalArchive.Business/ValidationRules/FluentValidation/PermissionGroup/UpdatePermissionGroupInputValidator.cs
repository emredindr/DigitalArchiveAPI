using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.PermissionGroupVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.PermissionGroup
{
    public class UpdatePermissionGroupInputValidator : AbstractValidator<UpdatePermissionGroupInput>
    {
        public UpdatePermissionGroupInputValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Name 50 karakterden fazla olamaz");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength200).WithMessage("Name 200 karakterden fazla olamaz");
        }
    }
}
