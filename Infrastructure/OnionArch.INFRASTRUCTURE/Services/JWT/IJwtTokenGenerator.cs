using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.Services.JWT
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }
}
