using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.DOMAIN.Concretes
{
    public  class AppUserRole:BaseEntity
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
