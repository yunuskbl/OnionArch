using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;
using OnionArch.PERSISTENCE.ContextClasses;

namespace OnionArch.PERSISTENCE.Repositories
{
    public class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(MyContext context) : base(context)
        {
                
        }
    }
}
