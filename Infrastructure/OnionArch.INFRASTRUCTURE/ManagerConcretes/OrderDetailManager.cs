using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.OrderDetails;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class OrderDetailManager:BaseManager<OrderDetail,OrderDetailDTO>,IOrderDetailManager
    {
        IOrderDetailRepository _repository;

        public OrderDetailManager(IOrderDetailRepository repository, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
    }
}
