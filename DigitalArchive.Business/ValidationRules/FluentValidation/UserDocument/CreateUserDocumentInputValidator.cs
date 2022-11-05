using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.UserDocumentVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.UserDocument
{
    public class CreateUserDocumentInputValidator: AbstractValidator<CreateUserDocumentInput>
    {
        public CreateUserDocumentInputValidator()
        {
            RuleFor(x => x.DocumentId).GreaterThanOrEqualTo(1).WithMessage("Döküman bilgisi bulunamadı");
            RuleFor(x => x.DocumentTitle).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength100).WithMessage("Name 100 karakterden fazla olamaz");
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1).WithMessage("Kullanıcı bilgisi seçilmelidir");
            RuleFor(x => x.CategoryId).GreaterThanOrEqualTo(1).WithMessage("Category bilgisi seçilmelidir");
        }
    }
}
