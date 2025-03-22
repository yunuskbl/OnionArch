using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.DOMAIN.Concretes
{
    public class Order:BaseEntity
    {
        public string ShippedAddress { get; set; }
        public int? AppUserID { get; set; } 

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderDetail> Details { get; set; }  
    }
}
