﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs;
using OnionArch.APPLICATION.DTOs.Orders;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.INFRASTRUCTURE.ManagerConcretes;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<Order, OrderDTO, IOrderManager>
    {
        public OrderController(IOrderManager orderManager,IMapper mapper) : base(orderManager,mapper)
        {

        }
    }
}
