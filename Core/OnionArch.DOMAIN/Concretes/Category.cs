using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.DOMAIN.Concretes
{
    public  class Category:BaseEntity
    {
        public string CategoryName { get; set; } 
        public string Description { get; set; } 


        public virtual ICollection<Product> Products { get; set; }
    }
}
