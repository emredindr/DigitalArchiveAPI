using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.CategoryVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.Category
{
    public class CreateCategoryInputValidator: AbstractValidator<CreateCategoryInput>
    {
        public CreateCategoryInputValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Name 50 karakterden fazla olamaz");
            RuleFor(x => x.ParentCategoryId).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryTypeId).GreaterThanOrEqualTo(1);

        }
    }
}
