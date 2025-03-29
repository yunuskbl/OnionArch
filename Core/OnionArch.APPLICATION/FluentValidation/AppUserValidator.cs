using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.FluentValidation
{
    public class AppUserValidator:AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
               RuleFor(x=>x.UserName)
                .NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez")
                .Length(3, 18).WithMessage("Kullanıcı Adı 3-18 Karakter Arasında Olmalıdır");
            RuleFor(x=>x.Password)
                .NotNull().WithMessage("Şifre Boş Geçilemez")
                .Length(6, 14).WithMessage("Şifre 6-18 Karakter Arasında Olmalıdır")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,14}$").WithMessage("Şifre En Az 1 Büyük Harf, 1 Küçük Harf, 1 Rakam ve 1 Özel Karakter İçermelidir");
        }
    }
}
