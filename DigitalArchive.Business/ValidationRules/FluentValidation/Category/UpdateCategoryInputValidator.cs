using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.CategoryVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.Category
{
    public class UpdateCategoryInputValidator:AbstractValidator<UpdateCategoryInput>
    {
        public UpdateCategoryInputValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Kategori adı 50 karakterden fazla olamaz");
            RuleFor(x => x.ParentCategoryId).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryTypeId).GreaterThanOrEqualTo(1).LessThanOrEqualTo(4);

        }
    }
}
