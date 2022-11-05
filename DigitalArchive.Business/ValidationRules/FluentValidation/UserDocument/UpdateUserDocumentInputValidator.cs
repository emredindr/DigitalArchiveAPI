using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.UserDocumentVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.UserDocument
{
    public class UpdateUserDocumentInputValidator : AbstractValidator<UpdateUserDocumentInput>
    {
        public UpdateUserDocumentInputValidator()
        {
            RuleFor(x => x.UserDocumentId).GreaterThanOrEqualTo(1).WithMessage("Güncelleme yapılacak döküman bilgisi bulunamadı");
            RuleFor(x => x.DocumentId).GreaterThanOrEqualTo(1).WithMessage("Döküman bilgisi bulunamadı");
            RuleFor(x => x.DocumentTitle).NotEmpty().WithMessage("Doküman adı zorunludur.").MaximumLength(CoreConsts.MaxLength100).WithMessage("Doküman adı  100 karakterden fazla olamaz");
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1).WithMessage("Kullanıcı bilgisi seçilmelidir");
            RuleFor(x => x.CategoryId).GreaterThanOrEqualTo(1).WithMessage("Category bilgisi seçilmelidir");
        }
    }
}
