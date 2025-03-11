using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.DOMAIN.Concretes
{
    public class AppRole:BaseEntity
    {
        public string RoleName { get; set; }

        public virtual ICollection<AppUserRole> UserRole { get; set; }
    }
}
