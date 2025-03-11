using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using OnionArch.APPLICATION.DTOs;
using OnionArch.APPLICATION.Managers;
using OnionArch.DOMAIN.Abstracts;

namespace OnionArch.WebAPI.Controllers.Abstract
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TDto, TManager> : ControllerBase
        where TEntity : class, IEntity
        where TDto : class, IDto
        where TManager : class, IManager<TEntity, TDto>
    {
        protected TManager _manager;
        protected IMapper _mapper;

        public BaseController(TManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet("api/get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<TDto> dtos = await _manager.GetAllAsync();
            
            return Ok(dtos);
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int Id)
        {
            IDto dtos = await _manager.GetByIdAsync(Id);
            return Ok(dtos);
        }

        
        [HttpPost("api/add")]

        public async Task<IActionResult> CreateAsync(TDto dto)
        {
            string message = await _manager.CreateAsync(dto);

            return Ok(message);
        }

        [HttpPut("api/update")]
        public async Task<IActionResult> UpdateAsync(TDto dto)
        {
            string message = await _manager.UpdateAsync(dto);
            return Ok(message);
        }
        [HttpPut("api/delete")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            TDto dto = await _manager.GetByIdAsync(Id);
            string message = await _manager.DeleteAsync(dto);
            return Ok(message);
        }
        [HttpDelete("api/remove")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            TDto dto = await _manager.GetByIdAsync(Id);
            string message = await _manager.RemoveAsync(dto);
            return Ok(message);
        }
    }
}
