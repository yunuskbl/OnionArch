using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.FluentValidation
{
    public class AppRoleValidator : AbstractValidator<AppRole>
    {
        public AppRoleValidator()
        {
            RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("Role name is required.")
            .Length(3, 20).WithMessage("Role name must be between 3 and 20 characters.");
        }
    }
}
