using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.DOMAIN.Concretes
{
    public class AppUserProfile:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AppUserId { get; set; } 

        public virtual AppUser AppUser { get; set; }
    }
}
