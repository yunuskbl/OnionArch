using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.Orders;
using OnionArch.APPLICATION.Managers;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.INFRASTRUCTURE.ManagerConcretes
{
    public class OrderManager:BaseManager<Order,OrdersDTO>,IOrderManager
    {
        IOrderRepository _repository;

        public OrderManager(IOrderRepository repository , IMapper mapper):base(repository,mapper)
        {
            _repository = repository;

        }
    }
}
