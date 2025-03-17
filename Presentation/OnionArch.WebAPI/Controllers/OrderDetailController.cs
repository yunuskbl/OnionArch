using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.APPLICATION.DTOs.OrderDetails;
using OnionArch.APPLICATION.Logging;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Concretes;
using OnionArch.WebAPI.Controllers.Abstract;

namespace OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : BaseController<OrderDetail,OrderDetailDTO,IOrderDetailManager>
    {
        public OrderDetailController(IOrderDetailManager manager, IMapper mapper, ILoggerService logger) : base(manager, mapper, logger)
        {
                
        }
    }
}
