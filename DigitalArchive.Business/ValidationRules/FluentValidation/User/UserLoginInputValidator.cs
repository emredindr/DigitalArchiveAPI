using DigitalArchive.Entities.UserVM;
using FluentValidation;

namespace DigitalArchive.Business.ValidationRules.FluentValidation.User
{
    public class UserLoginInputValidator : AbstractValidator<UserLoginInput>
    {
        public UserLoginInputValidator()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email alanı zorunludur.")
                     .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(s => s.Password).NotEmpty().WithMessage("Şifre zorunludur");
        }
    }
}
