using DigitalArchive.Core.Constants;
using DigitalArchive.Entities.ViewModels.UserVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.User
{
    public class CreateUserInputValidator :AbstractValidator<CreateUserInput>
    {
        public CreateUserInputValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50).WithMessage("Name 50 karakterden fazla olamaz");
            RuleFor(s => s.Surname).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50); ;
            RuleFor(s => s.UserName).NotEmpty().WithMessage("Name alanı zorunludur.").MaximumLength(CoreConsts.MaxLength50); ;
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email alanı zorunludur.")
                     .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.").MaximumLength(CoreConsts.MaxLength50); ;
           
        }

    }
}
