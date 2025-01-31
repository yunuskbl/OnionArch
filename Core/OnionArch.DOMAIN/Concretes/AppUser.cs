using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.DOMAIN.Concretes
{
    public  class AppUser:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual AppUserProfile Profile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<AppUserRole> Roles { get; set; }
    }
}
