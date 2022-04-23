using Asp.netCore_MVC_.Models;
using FluentValidation;

namespace Asp.netCore_MVC_.Biz
{

    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("لطفا نام را وارد کنید");
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("لطفا ایمیل را وارد کنید");
        }
    }

}
