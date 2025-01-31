using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.DOMAIN.Concretes
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }    
        public decimal UnitPrice { get; set; }    
        public int? CategoryId { get; set; }    

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
